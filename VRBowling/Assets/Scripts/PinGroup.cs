using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinGroup : MonoBehaviour
{
    public int m_PinCount = 0;
    public static PinGroup instance;
    bool m_BallEnyer = false;
    private List<PIn> fallenPins = new List<PIn>(); // 记录已经倒下的瓶

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Update()
    {
        if (m_BallEnyer)
        {
            HitPin();
        }
    }

    public void HitPin()
    {
        foreach (var p in GetComponentsInChildren<PIn>())
        {
            if (p.IsStandard() &&!fallenPins.Contains(p))
            {
                m_PinCount++;
                fallenPins.Add(p);
                UpdateScore(); // 调用更新分数的方法
            }
        }
    }

    /// <summary>
    /// 当球进入碰撞体时调用
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            m_BallEnyer = true;
            Sreen.instance.SetColor(Color.red);
        }
    }

    /// <summary>
    /// 当球离开碰撞体时调用
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            StartCoroutine(StopCalculate());
        }
    }

    /// <summary>
    /// 停止计算
    /// </summary>
    /// <returns></returns>
    IEnumerator StopCalculate()
    {
        yield return new WaitForSeconds(3f);
        m_BallEnyer = false;
        Sreen.instance.SetColor(Color.green);
    }

    // 更新分数的方法
    private void UpdateScore()
    {
        if (Sreen.instance != null)
        {
            Sreen.instance.UpdateScoreText(m_PinCount);
        }
    }
}