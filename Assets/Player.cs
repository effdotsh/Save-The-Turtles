using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    public float acceleration = 0.04f;
    public float decceleration = 0.0001f;

    public Rigidbody2D rb;
    public Text scoreText;
    public Text healthText;
    public float speedPerPoint;
    public float turnPerPoint;


    private int score = 0;
    public int health;

    private float angle = 0;

    private float d2r = Mathf.PI / 180;

    private float moveX = 0;
    private float moveY = 0;

    private float xPos;
    private float yPos;

    // Start is called before the first frame update
    void Start()
    {
        setScore();
    }

    // Update is called once per frame
    void FixedUpdate()
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
        rb.velocity = new Vector2(Mathf.Cos(angle * d2r) * moveY, Mathf.Sin(angle * d2r) * moveY);

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "trash")
        {
            Destroy(other.gameObject);
            score++;
            setScore();
            speed += speedPerPoint;
            turnSpeed += turnPerPoint;
        }
    }

    private void setScore()
    {
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
    }

    public void takeHit()
    {
        health--;
        setScore();
        if (health <= 0)
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }

            PlayerPrefs.SetInt("score", score);

            SceneManager.LoadScene("End Screen");
        }
    }
}