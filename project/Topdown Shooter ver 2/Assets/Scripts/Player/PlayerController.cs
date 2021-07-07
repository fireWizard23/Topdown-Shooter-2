using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RigidbodyController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 5f;
    [SerializeField] private float MovementLerpWeight = 0.15f;

    public enum States { Idle, Walking, InKnockback, Attacking}
    private States currentState = States.Idle;

    private RigidbodyController myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<RigidbodyController>();
        myRigidbody.MovementLerpWeight = MovementLerpWeight;
    }


    void Update()
    {
        currentState = GetNewState();
        DoStateLogic();

        if (Input.GetMouseButtonDown(0))
        {
//             print("RESETING");
//             reset = false;
//             MyUtils.Time.SetTimeout(() => {
//                 reset = false;
//             }, 0.2f, this);
        }

    }

    private void DoStateLogic()
    {
        switch(currentState)
        {
            default:
                float x = Input.GetAxisRaw("Horizontal");
                float y = Input.GetAxisRaw("Vertical");
                myRigidbody.velocity = new Vector2(x, y).normalized * MovementSpeed;
                break;
        }
    }

    private States GetNewState()
    {
        switch(currentState)
        {
            default:
            case States.Idle:
                if (myRigidbody.Rigidbody.velocity != Vector2.zero)
                    return States.Walking;
                return States.Idle;
            case States.Walking:
                if (myRigidbody.Rigidbody.velocity == Vector2.zero)
                    return States.Idle;
                return States.Walking;
                
        }
    }



}
