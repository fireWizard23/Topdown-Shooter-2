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

    //private WeaponNoticer weaponPickuper;
    private WeaponPickuper weaponPickuper;
    private InventoryComponent inventoryComponent;

    void Start()
    {
        myRigidbody = GetComponent<RigidbodyController>();
        inventoryComponent = GetComponent<InventoryComponent>();
        weaponPickuper = GetComponent<WeaponPickuper>();

        //weaponPickuper = GetComponent<WeaponNoticer>();
        myRigidbody.MovementLerpWeight = MovementLerpWeight;
        //// Subscribe
        //weaponPickuper.OnWeaponEnter += OnWeaponEnter;

    }

    //private void OnDestroy()
    //{
        // Unsubscribe
      //  weaponPickuper.OnWeaponEnter -= OnWeaponEnter;
    //}


    private void OnWeaponEnter(WeaponBase weapon)
    {
        print(weapon != null);
    }

    void Update()
    {
        currentState = GetNewState();
        DoStateLogic();

        if (Input.GetKeyDown(KeyCode.E))
        {
            //inventoryComponent.SetEquipped(weapon);
            print(weaponPickuper.GetNearestWeapon().gameObject.name);
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
