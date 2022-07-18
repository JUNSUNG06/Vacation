using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chong : MonoBehaviour
{
    [SerializeField] private Transform firePos = null;
    [SerializeField] private float maxDistacne = 100f;
    [SerializeField] private LayerMask enemyLayer;
    private float randAngle = 0;

    void Update()
    {
        Fire();
    }
    void Fire()
    {
        RaycastHit2D hit;
        Collider2D col = null;

        if (Input.GetMouseButtonDown(0)) 
        {
            randAngle = UnityEngine.Random.Range(-5, 6);
            firePos.localRotation = Quaternion.AngleAxis(randAngle, Vector3.forward);

            Debug.DrawRay(firePos.position, firePos.right * maxDistacne, Color.red, 0.1f);

            hit = Physics2D.Raycast(firePos.position, firePos.right, maxDistacne, enemyLayer);
            {
                if(hit)
                {
                    Debug.Log(1);
                }
            }        
        }
    }
}
