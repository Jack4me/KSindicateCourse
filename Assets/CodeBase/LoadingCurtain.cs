using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCurtain : MonoBehaviour {
    public CanvasGroup curtain;

    private void Awake(){
        DontDestroyOnLoad(this);
    }

    public void Show(){
        gameObject.SetActive(true);
        curtain.alpha = 1;
    }

    public void Hide() => StartCoroutine(DoFadeIn());

    private IEnumerator DoFadeIn(){
        while (curtain.alpha > 0){
            curtain.alpha -= 0.03f;
            yield return new WaitForSeconds(0.03f);
        }
        gameObject.SetActive(false);
    }
}