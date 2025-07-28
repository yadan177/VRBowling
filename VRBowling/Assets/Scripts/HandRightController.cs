using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HandRightController : MonoBehaviour
{
    private Animator anim;//动画状态机
    void Start()
    {
        anim = GetComponent<Animator>();//获取动画状态机
    }
    
    void Update()
    {
        InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.grip, out float gripValue);
        Debug.Log(gripValue);
        if (Input.GetKey(KeyCode.G))
        {
            gripValue = 1;
        }
        else
        {
            gripValue = 0;
        }
        anim.SetFloat("Grab", gripValue);
    }
}
