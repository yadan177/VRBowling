using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public static BallPool instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    /// <summary>
    /// 生成保龄球
    /// </summary>
    public GameObject Spawn()
    {
        if (transform.childCount > 0)
        {
            //获取第一个子物体
            GameObject go = transform.GetChild(0).gameObject;
            //显示保龄球
            go.SetActive(true);
            //取消父物体
            go.transform.SetParent(null);
            //唤醒刚体
            go.GetComponent<Rigidbody>().WakeUp();
            return go;
        }
        else
        {
            return null;
        }
        
    }
    /// <summary>
    /// 隐藏保龄球
    /// </summary>
    /// <param name="GO">要隐藏的保龄球</param>
    public void UnSpawn(GameObject GO)
    {
        //让保龄球刚体休眠
        GO.transform.GetComponent<Rigidbody>().Sleep();
        //将保龄球父物体设置为当前物体
        GO.transform.SetParent(transform,true);
        //隐藏保龄球
        GO.SetActive(false);
    }
}
