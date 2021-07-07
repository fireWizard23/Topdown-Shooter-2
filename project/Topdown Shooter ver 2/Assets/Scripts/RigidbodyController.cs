using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyController : MonoBehaviour
{
    [HideInInspector] public Vector2  velocity;

    private Rigidbody2D myRigidbody;
    public Rigidbody2D Rigidbody => myRigidbody;
    public float MovementLerpWeight = 0.1f;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (velocity != null)
        {
            myRigidbody.velocity = Vector2.Lerp(myRigidbody.velocity, velocity, MovementLerpWeight);
            if(myRigidbody.velocity.sqrMagnitude <= 0.2f * 0.2f)
            {
                myRigidbody.velocity = Vector2.zero;
            }
        }
    }
}
