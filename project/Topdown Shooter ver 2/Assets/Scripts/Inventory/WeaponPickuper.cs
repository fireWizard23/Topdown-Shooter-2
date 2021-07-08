using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponNotifier))]
public class WeaponPickuper : MonoBehaviour
{
    [SerializeField] private int MaxNearWeapons = 10;
    
    private List<WeaponDropBase> nearWeapons;

    
    private WeaponNotifier weaponNotifier;

    // Start is called before the first frame update
    void Start()
    {
        nearWeapons = new List<WeaponDropBase>(MaxNearWeapons);
        weaponNotifier = GetComponent<WeaponNotifier>();
        // Subscribe
        weaponNotifier.OnWeaponEnter += OnWeaponEnter;
        weaponNotifier.OnWeaponExit += OnWeaponExit;
    }

    

    private void OnDestroy()
    {
        // Unsubscribe
        weaponNotifier.OnWeaponEnter -= OnWeaponEnter;
        weaponNotifier.OnWeaponExit -= OnWeaponExit;

    }

    private void OnWeaponExit(WeaponDropBase weapon)
    {
        nearWeapons.Remove(weapon);
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 distance = new Vector2();
        WeaponDropBase nearest = GetNearestWeapon(out distance);
        if (distance.sqrMagnitude <= 3 * 3)
        {
            // Notify the whatever input system is
        }
    }

    private void OnWeaponEnter(WeaponDropBase weapon)
    {
        if (nearWeapons.Count >= MaxNearWeapons)
            nearWeapons.RemoveAt(0);
        nearWeapons.Add(weapon);
    }

    public WeaponDropBase GetNearestWeapon(out Vector2 distanceOfNearest)
    {
        WeaponDropBase nearest = GetNearestWeapon();
        if (nearest != null)
        {
            distanceOfNearest = (nearest.gameObject.transform.position - transform.position);
        }
        else
            distanceOfNearest = new Vector2();
        return nearest;
    }
    public WeaponDropBase GetNearestWeapon()
    {
        if (nearWeapons.Count <= 0)
            return null;

        WeaponDropBase nearest = nearWeapons[0];
        Vector2 distanceOfNearest = (nearest.gameObject.transform.position - transform.position);
        for (int i = 1; i < nearWeapons.Count - 1; i++)
        {
            WeaponDropBase iWeapon = nearWeapons[i];
            Vector2 distanceOfI = (iWeapon.gameObject.transform.position - transform.position);
            distanceOfNearest = (nearest.gameObject.transform.position - transform.position);
            if (distanceOfI.sqrMagnitude < distanceOfNearest.sqrMagnitude)
                nearest = iWeapon;
        }
        return nearest;
    }

}
