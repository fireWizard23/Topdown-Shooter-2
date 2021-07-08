using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponNotifier))]
public class WeaponPickuper : MonoBehaviour
{
    [SerializeField] private int MaxNearWeapons = 10;
    
    private List<WeaponBase> nearWeapons;

    
    private WeaponNotifier weaponNotifier;

    // Start is called before the first frame update
    void Start()
    {
        nearWeapons = new List<WeaponBase>(MaxNearWeapons);
        weaponNotifier = GetComponent<WeaponNotifier>();
        // Subscribe
        weaponNotifier.OnWeaponEnter += OnWeaponEnter;
    }

    

    private void OnDestroy()
    {
        // Unsubscribe
        weaponNotifier.OnWeaponEnter -= OnWeaponEnter;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 distance = new Vector2();
        WeaponBase nearest = GetNearestWeapon(out distance);
        if (distance.sqrMagnitude <= 3 * 3)
        {
            // Notify the whatever input system is
        }
    }

    private void OnWeaponEnter(WeaponBase weapon)
    {
        if (nearWeapons.Count >= MaxNearWeapons)
            nearWeapons.RemoveAt(0);
        nearWeapons.Add(weapon);
    }

    public WeaponBase GetNearestWeapon(out Vector2 distanceOfNearest)
    {
        WeaponBase nearest = GetNearestWeapon();
        if (nearest != null)
        {
            distanceOfNearest = (nearest.gameObject.transform.position - transform.position);
        }
        else
            distanceOfNearest = new Vector2();
        return nearest;
    }
    public WeaponBase GetNearestWeapon()
    {
        if (nearWeapons.Count <= 0)
            return null;

        WeaponBase nearest = nearWeapons[0];
        Vector2 distanceOfNearest = (nearest.gameObject.transform.position - transform.position);
        for (int i = 1; i < nearWeapons.Count - 1; i++)
        {
            WeaponBase iWeapon = nearWeapons[i];
            Vector2 distanceOfI = (iWeapon.gameObject.transform.position - transform.position);
            if (distanceOfI.sqrMagnitude > 3 * 3)
            {
                nearWeapons.RemoveAt(i);
                continue;
            }
            distanceOfNearest = (nearest.gameObject.transform.position - transform.position);
            if (distanceOfI.sqrMagnitude < distanceOfNearest.sqrMagnitude)
                nearest = iWeapon;
        }
        return nearest;
    }

}
