using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyController : MonoBehaviour
{
    [HideInInspector] public Vector2  velocity;

    private Rigidbody2D myRigidbody;
    public Rigidbody2D Rigidbody => myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (velocity != null)
            Rigidbody.velocity = velocity;
    }
}
