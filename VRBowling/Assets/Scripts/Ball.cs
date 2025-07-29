using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool m_isGrabbed = false;//是否被抓取
    private float m_UnSpawnTime = 9f;//回收时间
    float m_UnSpawnTimer = 0f;

    private void Update()
    {
        if (m_isGrabbed)
        {
            m_UnSpawnTimer += Time.deltaTime;
            if (m_UnSpawnTimer >= m_UnSpawnTime)
            {
                UnSpawn();
            }
        }
    }

    public void UnSpawn()
    {
        m_UnSpawnTimer = 0;
        m_isGrabbed = false;
        BallPool.instance.UnSpawn(gameObject);
    }
    /// <summary>
    /// 进入抓取
    /// </summary>
    public void GrabEnter()
    {
        m_isGrabbed = false;
        BallSpawn.instance.BallCount--;
    }
    /// <summary>
    /// 退出抓取
    /// </summary>
    public void GrabExit()
    {
        m_isGrabbed = true;
    }
}
