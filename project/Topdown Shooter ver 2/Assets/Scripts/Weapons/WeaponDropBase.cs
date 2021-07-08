using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponDropBase : MonoBehaviour
{
    public Type type = Type.Melee;

    public abstract void Attack();

}

public enum Type { Melee, Ranged }



