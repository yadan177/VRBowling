using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StartCanvas : MonoBehaviour
{
    public Transform m_BtnStart;//开始按钮
    public Transform m_BtnEnd;//结束按钮
   private AsyncLoading asyncLoading;//异步加载组件
    void Start()
    {
        asyncLoading=GetComponentInChildren<AsyncLoading>();
    }
    #region 开始按钮点击、进入、退出
    public void OnStartClick()
    {
        asyncLoading.LoadingInterface();
    }
    public void OnStart_EnterClick()
    {
        m_BtnStart.DOScale(Vector3.one * 1.1f, 0.1f);
    }
    public void OnStart_ExitClick()
    {
        m_BtnStart.DOScale(Vector3.one * 1f, 0.1f);
    }

    #endregion

    #region 退出按钮点击、进入、退出
    public void OnEndClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void OnEnd_EnterClick()
    {
        m_BtnEnd.DOScale(Vector3.one * 1.1f, 0.1f);
    }
    public void OnEnd_ExitClick()
    {
        m_BtnEnd.DOScale(Vector3.one * 1f, 0.1f);
    }

    #endregion
}
