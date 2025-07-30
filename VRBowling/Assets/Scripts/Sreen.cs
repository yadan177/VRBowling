using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sreen : MonoBehaviour
{
    public static Sreen instance;
    public Text m_txtScore;

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
}