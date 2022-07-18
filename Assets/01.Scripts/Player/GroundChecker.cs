using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private bool isGround = false;
    public bool IsGround { get => isGround; }

    private void Update() 
    {
        CheckGround();    
    }

    private void CheckGround() 
    {
        Vector2 pos = transform.position;
        Vector2 size = transform.localScale;


        Collider2D col = Physics2D.OverlapBox(pos, size, 0, 1 << 7);

        isGround = col;
    }
}
