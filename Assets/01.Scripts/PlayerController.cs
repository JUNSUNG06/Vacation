using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpPower = 3f;

    Rigidbody2D rb = null;
    GroundChecker gc = null;
    Hand hand = null;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        gc = GameObject.Find("Player/GroundChecker").GetComponent<GroundChecker>();
        hand = GameObject.Find("Player/Hand").GetComponent<Hand>();
    }

    private void Update() 
    {
        Move();
        Jump();
    }

    private void Move() 
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 moveVec = new Vector2(h * moveSpeed, rb.velocity.y);

        rb.velocity = moveVec;

        if(hand.isRight) { transform.rotation = Quaternion.Euler(0, 180, 0); }
        else { transform.rotation = Quaternion.Euler(0, 0, 0); }
    }

    private void Jump() 
    {
        if(Input.GetButtonDown("Jump") && gc.IsGround)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

}
