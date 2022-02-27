using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{

    [SerializeField]
    Vector3 mVelocity;

    [SerializeField]
    float Health = 100;

    Rigidbody mRigidbody;

    float pauseTimer;

    // Start is called before the first frame update
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        mRigidbody.AddForce(mVelocity, ForceMode.Acceleration);
    }
    private void Update()
    {
        if (pauseTimer > 0)
        {
            pauseTimer -= Time.deltaTime;

            if (pauseTimer <= 0)
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

        return Health > 0;
    }

}
