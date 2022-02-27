using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MovingWall : MonoBehaviour
{

    [SerializeField]
    Vector3 mVelocity;

    [SerializeField]
    float Health = 100;

    Rigidbody mRigidbody;

    float pauseTimer;

    public UnityAction<bool> GameEndAction;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        mRigidbody.velocity =mVelocity;
    }
    private void Update()
    {
        if (pauseTimer > 0)
        {
            pauseTimer -= Time.deltaTime;

            if (pauseTimer < 0)
            { 
                mRigidbody.velocity = mVelocity;
                pauseTimer = 0;
            }
        }
    }


    public void PauseWall(float _duration)
    {
        pauseTimer += _duration;
        mRigidbody.velocity = Vector3.zero;
    }


    public bool TakeDamage(float _damage)
    {
        Health -= _damage;
        healthBar.value = Health;

        if(Health <= 0)
            GameEndAction.Invoke(true);

        return Health > 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEndAction.Invoke(false);
        }
    }


}
