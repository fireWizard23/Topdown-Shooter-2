using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public Type type = Type.Melee;



}

public enum Type { Melee, Ranged }



