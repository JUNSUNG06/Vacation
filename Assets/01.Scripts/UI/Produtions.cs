using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Produtions : MonoBehaviour
{
    [SerializeField] private float fadeTime = 1f;

    GameObject canvas = null;
    GameObject startPanel = null;
    GameObject selectPanel = null;

    private Vector3 imagePos;

    private bool isSlide = false;

    private void Awake() 
    {
        canvas = GameObject.Find("Canvas").gameObject;
        startPanel = canvas.transform.Find("StartPanel").gameObject;
        selectPanel = canvas.transform.Find("SelectPanel").gameObject;    
    }

    public void FadeIn(Image image) 
    {
        image.DOFade(1, fadeTime);
    }

    public void FadeOut(Image image)
    {
        image.DOFade(0, fadeTime);
    }

    public void SlideRight(RectTransform image) 
    {
        float maxPos = -((image.childCount - 1) * image.rect.width);
        Debug.Log(maxPos);
        if(isSlide || image.localPosition.x == maxPos) return;
        isSlide = true;
        image.DOLocalMoveX(image.localPosition.x - image.rect.width, 1).SetEase(Ease.Linear).OnComplete(() => isSlide = false);
    }

    public void SlideLeft(RectTransform image) 
    {
        if(isSlide || image.localPosition.x == 0) return;
        isSlide = true;
        image.DOLocalMoveX(image.localPosition.x + image.rect.width, 1).SetEase(Ease.Linear).OnComplete(() => isSlide = false);
    }

    public void SlideUP(RectTransform image)
    {
        if(isSlide) return;
        isSlide = true;
        image.DOLocalMoveY(image.localPosition.y + image.rect.height, 1).SetEase(Ease.Linear).OnComplete(() => isSlide = false);
    }

    public void SlideDown(RectTransform image)
    {
        if(isSlide) return;
        isSlide = true;
        image.DOLocalMoveY(image.localPosition.y - image.rect.height, 1).SetEase(Ease.Linear).OnComplete(() => isSlide = false);
    }

    public void GameStart(RectTransform fadeImage)
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(fadeImage.DOLocalMoveY(0, 1).SetEase(Ease.Linear).OnComplete( () =>
        {
            startPanel.SetActive(false);
            selectPanel.SetActive(true);
        })
        );
        seq.Insert(2.5f, fadeImage.DOLocalMoveY(fadeImage.localPosition.y + fadeImage.rect.height, 1).SetEase(Ease.Linear));
    }
}
