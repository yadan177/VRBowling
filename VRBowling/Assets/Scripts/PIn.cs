using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PIn : MonoBehaviour
{
    private const float Rotation = 30f;

    public bool IsStandard()
    {
        float rotationAngle = Quaternion.Angle(transform.rotation, Quaternion.identity);
        return rotationAngle > Rotation;
    }
    
}
