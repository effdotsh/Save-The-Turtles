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

    private float d2r = Mathf.PI / 180f;
    // Start is called before the first frame update
    void Start()
    {
        moveAngle = Random.value * 360 * d2r;
        
        moveX = Mathf.Cos(moveAngle) * speed;
        moveY = Mathf.Sin(moveAngle) * speed;
        print(moveX);
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        
        if (rb.position.x > 16 || rb.position.x < -16)
        {
            moveX *= -1;
        }
        if (rb.position.y > 10 || rb.position.y < -10)
        {
            moveY *= -1;
        }

        xPos = Mathf.Clamp(xPos, -16, 16);
        yPos = Mathf.Clamp(yPos, -10, 10);

        transform.position.Set(xPos, yPos, transform.position.z);
        
        rb.velocity = new Vector2(moveX, moveY);
    }
}
