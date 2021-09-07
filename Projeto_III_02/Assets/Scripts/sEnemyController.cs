using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sEnemyController : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 4f;
    public bool playerMooved = false;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(playerMooved == true)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(pos);
            transform.LookAt(playerTransform);
        }
    }
}