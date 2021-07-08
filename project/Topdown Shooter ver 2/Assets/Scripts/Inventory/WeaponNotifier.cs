using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponNotifier : MonoBehaviour
{

    [SerializeField] private float PickupRadius = 3f;
    [SerializeField] private LayerMask PickupMask = 1;

    public Action<WeaponDropBase> OnWeaponEnter;
    public Action<WeaponDropBase> OnWeaponExit;
    private List<WeaponDropBase> weaponEntered;

    private List<int> toRemove = new List<int>();

    private void Start()
    {
        weaponEntered = new List<WeaponDropBase>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, PickupRadius, Vector3.forward, 1f, PickupMask);
        foreach(RaycastHit2D hit in hits)
        {
            WeaponDropBase weapon = hit.collider.GetComponent<WeaponDropBase>();
            if (weapon)
            {
                if(!weaponEntered.Contains(weapon))
                {
                    OnWeaponEnter?.Invoke(weapon);
                    weaponEntered.Add(weapon);
                }
            }
        }
        toRemove.Clear();
        
        for (int i = 0; i < weaponEntered.Count; i++)
        {
            WeaponDropBase weapon = weaponEntered[i];
            Vector2 distance = weapon.transform.position - transform.position;
            if(distance.sqrMagnitude > PickupRadius * PickupRadius)
            {
                MyUtils.Print("WEapon being removed", distance.sqrMagnitude, PickupRadius * PickupRadius);
                OnWeaponExit?.Invoke(weapon);
                toRemove.Add(i);
            }
        }
        foreach(int i in toRemove)
        {
            weaponEntered.RemoveAt(i);
        }

    }
}
