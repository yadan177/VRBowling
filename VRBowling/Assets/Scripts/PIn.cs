using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PIn : MonoBehaviour
{
    private const float Rotation = 40f;
    public Vector3 m_StartPos;
    public Quaternion m_StartRot;
    public void Start()
    {
        m_StartPos = transform.position;
        m_StartRot = transform.rotation;
    }
    public bool IsStandard()
    {
        float rotationAngle = Quaternion.Angle(transform.rotation, Quaternion.identity);
        return rotationAngle > Rotation;
    }
    
}
