using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed = 10f;
    private float secondsToStart = 1f;

    private Rigidbody2D rb2d;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb2d = GetComponent<Rigidbody2D>();
        GoBall();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Reset());
        }
    }

    private void GoBall()
    {
        if (UnityEngine.Random.value > 0.5f)
        {
            rb2d.velocity = Vector2.right * speed;
        }
        else
        {
            rb2d.velocity = Vector2.left * speed;
        }
    }

    private IEnumerator Reset()
    {
        rb2d.velocity = Vector2.zero;
        rb2d.position = Vector2.zero;
        yield return new WaitForSeconds(secondsToStart);
        GoBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameManager) return;
        bool isLeftScore;

        if (collision.gameObject.tag == "Goal")
        {
            if (collision.rigidbody.position.x > 0)
            {
                isLeftScore = false;
            }
            else
            {
                isLeftScore = true;
            }

            gameManager.ScoreUp(isLeftScore);
            StartCoroutine(Reset());
        }
        else
        {
            if (rb2d.velocity.y > 0)
            {
                rb2d.velocity = rb2d.velocity + BallAngle();
            }
            else if (rb2d.velocity.y < 0)
            {
                rb2d.velocity = rb2d.velocity - BallAngle();
            }
            else
            {
                if (UnityEngine.Random.Range(-1, 2) > 0)
                {
                    rb2d.velocity = rb2d.velocity + BallAngle();
                }
                else
                {
                    rb2d.velocity = rb2d.velocity - BallAngle();
                }
            }
        }
    }

    private Vector2 BallAngle()
    {
        Vector2 angle = new Vector2();
        angle.y = UnityEngine.Random.value;
        return angle;
    }
}
