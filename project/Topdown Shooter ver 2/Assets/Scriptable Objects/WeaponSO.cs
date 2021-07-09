using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSO : ScriptableObject
{
    public string Name = "Weapon_1";
    [Space]
    public float AttackDamage = 10f;
    public float AttackCooldown = 2;
    public LayerMask AttackMask = 1;

}
