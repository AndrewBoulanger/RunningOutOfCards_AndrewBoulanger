using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using EPOOutline;
public enum AnimStates
{
    Idle, Movement, Interact
}
public static class PlayerState
{
    public static bool isIdle, isMoving, isPickingUp, isDead;
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float m_accelationRate, m_MaxSpeed;
    
    [SerializeField, Range(0,1)]
    float deceleration = 0.15f;

    Vector2 m_dirInput;

     int animStateHash;

    PlayerInput m_inputs;
    Rigidbody m_rigidbody;
    Animator m_animator;

    CardsBehaviour overlappingCard = null;

    [SerializeField]
    GameManager manager;

    private void Awake()
    {
        m_inputs = GetComponent<PlayerInput>();
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();

        animStateHash = Animator.StringToHash("AnimState"); 

        m_inputs.actions["Movement"].performed += context => OnMovementInput(context.ReadValue<Vector2>());
         m_inputs.actions["Movement"].canceled += _ => OnMovementInput(Vector2.zero);
        m_inputs.actions["Interact"].performed += _ => OnInteract();
    }

    private void FixedUpdate()
    {
        if(PlayerState.isPickingUp || PlayerState.isDead )
        {
            m_rigidbody.velocity = Vector3.zero;
            return;
        }

        if(m_dirInput != Vector2.zero)
        {
            Vector3 moveDir = new Vector3(m_dirInput.x, 0.0f, m_dirInput.y);
            m_rigidbody.AddForce(moveDir * m_accelationRate, ForceMode.Impulse );

            m_animator.SetInteger(animStateHash, (int)AnimStates.Movement);

            Quaternion rotate = Quaternion.LookRotation(moveDir, Vector3.up);
            m_rigidbody.rotation = rotate;

            if(m_rigidbody.velocity.sqrMagnitude > m_MaxSpeed * m_MaxSpeed)
            {
                Vector3 _velocity = m_rigidbody.velocity;
                _velocity = Vector3.ClampMagnitude(_velocity, m_MaxSpeed);
                m_rigidbody.velocity = _velocity;
            }
        }
        else if(m_rigidbody.velocity.sqrMagnitude > deceleration * deceleration)
        {
            m_rigidbody.velocity *= (1 - deceleration);
        }
        else
        {
            m_rigidbody.velocity = Vector3.zero;
            m_animator.SetInteger(animStateHash, (int)AnimStates.Idle);
        }
    }

    void OnMovementInput(Vector2 _input)
    {
        m_dirInput = _input;
    }

    void OnInteract()
    {
        print(overlappingCard);
        if(overlappingCard != null)
        {
            PlayerState.isPickingUp = true;
            m_animator.SetInteger(animStateHash, (int)AnimStates.Interact);
            StartCoroutine("PickUpDelay");

        }
    }
    IEnumerator PickUpDelay()
    {
        yield return new WaitForSeconds(0.5f);
        if (manager.AddToCardsToPlay(overlappingCard.mEffect))
        {
            overlappingCard.gameObject.SetActive(false);
            overlappingCard = null;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Card"))
        {
            overlappingCard = other.GetComponent<CardsBehaviour>();
            if(other.transform.parent.TryGetComponent<Outlinable >(out Outlinable card))
            {
                card.enabled = true;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Card"))
        {
            overlappingCard = null;
            if (other.transform.parent.TryGetComponent<Outlinable>(out Outlinable card))
            {
                card.enabled = false;
            }
        }
    }

}
