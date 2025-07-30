using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sreen : MonoBehaviour
{
    public static Sreen instance;
    public Text m_txtScore;
    public Transform m_BtnReset;
    public Transform m_BtnExit;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        m_txtScore.text = 0.ToString()+"分";
    }

    public void UpdateScoreText(int score)
    {
        m_txtScore.text = score.ToString()+"分";
    }

    public void SetColor(Color color)
    {
        m_txtScore.color = color;
    }
    
    #region 重置及退出按钮
    /// <summary>
    /// 重置按钮进入
    /// </summary>
    public void OnResetEnter()
    {
        m_BtnReset.DOScale(Vector3.one*0.047f, 0.1f);
    }
    /// <summary>
    /// 重置按钮离开
    /// </summary>
    public void OnResetExit()
    {
        m_BtnReset.DOScale(Vector3.one*0.045f, 0.1f);
    }
    /// <summary>
    /// 重置按钮点击
    /// </summary>
    public void OnResetClick()
    {
        PinGroup.instance.ResetPin();
        UpdateScoreText(0);
        SetColor(Color.white);
    }
    /// <summary>
    /// 退出按钮进入
    /// </summary>
    public void OnExitEnter()
    {
        m_BtnExit.DOScale(Vector3.one*0.047f, 0.1f);
    }
    /// <summary>
    /// 退出按钮离开
    /// </summary>
    public void OnExitExit()
    {
        m_BtnExit.DOScale(Vector3.one*0.045f, 0.1f);
    }

    /// <summary>
    /// 退出按钮点击
    /// </summary>
    public void OnExitClick()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}