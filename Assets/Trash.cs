using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public class Trash : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform transform;
    public float speed;
    private float moveAngle;

    private float moveX;
    private float moveY;
    private float xPos;
    private float yPos;

    private float d2r = Mathf.PI / 180f;

    // Start is called before the first frame update
    void Start()
    {
        moveAngle = Random.value * 360 * d2r;

        moveX = Mathf.Cos(moveAngle) * speed;
        moveY = Mathf.Sin(moveAngle) * speed;
        rb.velocity = new Vector2(moveX, moveY);
    }

    // Update is called once per frame
    void Update()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;


        if (xPos > 16 || xPos < -16)
        {
            swapDir(-1, 1);
        }

        if (yPos > 10 || yPos < -10)
        {
            swapDir(1, -1);
            moveY *= -1;
        }
    }

    void swapDir(int changeX, int changeY)
    {
        xPos = Mathf.Clamp(xPos, -16, 16);
        yPos = Mathf.Clamp(yPos, -10, 10);

        transform.position.Set(xPos, yPos, transform.position.z);


        moveX = rb.velocity.x * changeX;
        moveY = rb.velocity.y * changeY;
        
        rb.velocity = new Vector2(moveX, moveY);
    }
}