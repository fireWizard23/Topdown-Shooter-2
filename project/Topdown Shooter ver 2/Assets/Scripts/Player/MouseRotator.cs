using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotator : MonoBehaviour
{
    private Vector3 zAxis = Vector3.forward;
    [SerializeField] private float LerpWeight = 0.1f;


    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(MyUtils.VectorUtils.GetAngle
            (MyUtils.CameraUtils.GetMouseDirection(transform.position)), zAxis),
            LerpWeight);
    }
}
