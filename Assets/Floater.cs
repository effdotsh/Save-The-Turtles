using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Floater : MonoBehaviour
{
    public Rigidbody2D rb;
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
        rb.rotation = Mathf.Atan2(moveY, moveX)/d2r;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        xPos = pos.x;
        yPos = pos.y;
        if (Mathf.Abs(xPos) > 18 )
        {
            xPos *= -1;
            transform.position = new Vector3(xPos, yPos, pos.z);
        }
        if (Mathf.Abs(yPos) > 11)
        {
            yPos *= -1;
            transform.position = new Vector3(xPos, yPos, pos.z);
        }
    }
    
}