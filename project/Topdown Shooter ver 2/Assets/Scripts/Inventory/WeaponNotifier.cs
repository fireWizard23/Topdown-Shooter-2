using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponNotifier : MonoBehaviour
{

    [SerializeField] private float PickupRadius = 3f;
    [SerializeField] private LayerMask PickupMask = 1;

    public Action<WeaponBase> OnWeaponEnter;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, PickupRadius, Vector3.forward, 1f, PickupMask);
        foreach(RaycastHit2D hit in hits)
        {
            WeaponBase weapon = hit.collider.GetComponent<WeaponBase>();
            if (weapon)
                OnWeaponEnter?.Invoke(weapon);
        }
    }
}
