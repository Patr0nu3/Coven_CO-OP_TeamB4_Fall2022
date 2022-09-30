using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Object : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();   
    }

    void Update()
    {
        rb.velocity = rb.velocity * 0.95f * Time.deltaTime;
    }
}

