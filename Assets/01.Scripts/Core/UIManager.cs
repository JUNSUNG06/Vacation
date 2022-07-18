using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    private void Awake() 
    {
        if(Instance == null) { Instance = this; }    
    } 

    public void FadeIn(Image image, float time) 
    {
        image.DOFade(1, time);
    }

    public void FadeOut(Image image, float time)
    {
        image.DOFade(0, time);
    }
}
