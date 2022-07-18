using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    private Image fadeImage = null;

    private void Awake() 
    {
        if(Instance == null) { Instance = this; }    

        fadeImage = GameObject.Find("FadeImage").GetComponent<Image>();
    }

    private void Start() 
    {
        fadeImage.DOFade(0, 2);
    }
}
