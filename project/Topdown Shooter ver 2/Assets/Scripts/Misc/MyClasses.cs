using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyClasses : MonoBehaviour
{
    public interface IMeleeAttacker
    {
        public Action AttackMethod { get; set; }
    }




}
