using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    public float acceleration = 0.04f;
    public float decceleration = 0.0001f;

    public Rigidbody2D rb;
    public TextAsset score;
    private float angle = 0;

    private float d2r = Mathf.PI / 180;

    private float moveX = 0;

    private float moveY = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveY -= decceleration * moveY / (Mathf.Abs(moveY) + 0.001f);
        moveX = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX -= turnSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX += turnSpeed;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveY += acceleration;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveY -= acceleration;
        }
        
        angle -= moveX;
        rb.rotation = angle;

        moveY = Mathf.Clamp(moveY, -speed, speed);
        rb.velocity = new Vector2(Mathf.Cos(angle * d2r) * moveY, Mathf.Sin(angle * d2r) *  moveY);
        

    }

    private void OnCollisionEnter(Collision other)
    {
        print(Time.time);
        if (other.gameObject.tag == "trash")
        {
            Destroy(other.gameObject);
        }
    }
}