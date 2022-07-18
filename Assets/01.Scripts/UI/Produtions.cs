using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Produtions : MonoBehaviour
{
    [SerializeField] private float fadeTime = 1f;

    private Vector3 imagePos;

    private bool isSlide = false;

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
}
