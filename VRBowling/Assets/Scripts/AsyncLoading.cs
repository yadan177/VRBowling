using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoading : MonoBehaviour
{
    AsyncOperation asyncOperation;//异步加载
    Animation anim;//动画组件
    void Start()
    {
        anim=GetComponent<Animation>();
        transform.localScale = Vector3.zero;
    }
    //加载场景界面
    public void LoadingInterface()
    {
        anim.Play("LoadingInterface");
        transform.DOScale(Vector3.one, 0.3f).OnComplete(() =>
        {
            StartCoroutine(StartLoading());
        });
    }
    //异步加载场景
    IEnumerator StartLoading()
    {
        asyncOperation=SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;
        yield return new WaitForSeconds(3f);
        asyncOperation.allowSceneActivation = true;
    }
    
}
