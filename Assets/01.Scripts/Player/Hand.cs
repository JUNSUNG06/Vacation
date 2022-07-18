using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float maxDistacne = 5f;
    public bool isRight = false;

    Transform playerTrm = null;

    private void Awake() 
    {
        playerTrm = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update() 
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        Vector3 pos;
        
        if(mousePos.x < playerTrm.transform.position.x) { isRight = true; }
        else if(mousePos.x > playerTrm.transform.position.x) { isRight = false; }

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(isRight) { angle = Mathf.Atan2(dir.y, -dir.x) * Mathf.Rad2Deg; }

        transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
