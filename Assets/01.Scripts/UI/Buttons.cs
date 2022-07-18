using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private float fadeTime = 1f;

    GameObject canvas = null;
    GameObject startPanel = null;
    GameObject selectPanel = null;

    private void Awake() 
    {
        canvas = GameObject.Find("Canvas").gameObject;
        startPanel = canvas.transform.Find("StartPanel").gameObject;
        selectPanel = canvas.transform.Find("SelectPanel").gameObject;    
    }
    public void StartBtn(RectTransform fadeImage)
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(fadeImage.DOLocalMoveY(0, 1).SetEase(Ease.Linear).OnComplete( () =>
        {
            startPanel.SetActive(false);
            selectPanel.SetActive(true);
        })
        );
        seq.Insert(2.5f, fadeImage.DOLocalMoveY(fadeImage.rect.height, 1).SetEase(Ease.Linear));
    }

    public void SelectBtn(CanvasGroup image)
    {
        Sequence seq = DOTween.Sequence();

        seq.Insert(1.3f, image.DOFade(0, fadeTime).OnComplete(() => SceneManager.LoadScene("Play") ));
    }
}
