using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RigidbodyController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 5f;
    [SerializeField] private float MovementLerpWeight = 0.15f;


    private RigidbodyController myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<RigidbodyController>();
        myRigidbody.MovementLerpWeight = MovementLerpWeight;
    }

    bool reset = false;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //myRigidbody.velocity = Vector2.Lerp(myRigidbody.velocity, new Vector2(x, y).normalized * MovementSpeed, MovementLerpWeight);
        myRigidbody.velocity = new Vector2(x, y).normalized * MovementSpeed;
        if(reset)
            myRigidbody.velocity = Vector2.zero;

        if (Input.GetMouseButtonDown(0))
        {
            print("RESETING");
            reset = false;
            MyUtils.Time.SetTimeout(() => {
                reset = false;
            }, 0.2f, this);
        }

    }
}
