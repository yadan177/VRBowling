using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    #region 字段
    public static BallSpawn instance;
    private GameObject ballPrefab;//保龄球预制体
    float m_spawnInterval=2f;//生成间隔
    float m_spawnTimer=0f;//生成定时器
    int _mBallCount=0;//当前球的数量
    #endregion

    #region 属性
    public int BallCount
    {
        get => _mBallCount;
        set
        {
            _mBallCount = Mathf.Clamp(value, 0, 5);
        }
    }
    #endregion
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        ballPrefab = Resources.Load<GameObject>("Objects/Ball");
    }

    private void Update()
    {
        m_spawnTimer+=Time.deltaTime;
        if(m_spawnTimer>=m_spawnInterval&&BallCount<5)
        {
            m_spawnTimer=0;
            Spawn();
        }
    }

    /// <summary>
    /// 生成保龄球
    /// </summary>
    public void Spawn()
    {
        GameObject ball;
        if (BallPool.instance.transform.childCount > 0)
        {
            ball = BallPool.instance.Spawn();
        }
        else
        {
            ball=Instantiate(ballPrefab);
        }
        ball.transform.position = transform.position;
        ball.transform.rotation = transform.rotation;
        BallCount++;
    }
}
