using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigibody;
    public Vector2 direction;
    public float speed;
    public float basespeed;
    public float coefficientspeed;
    public int points;
    public Player player;
    void Start()
    {
        transform.position = Vector2.zero;
        direction = new Vector2(Random.Range(0.5f,1),Random.Range(0.5f,1)); //стартовый вектор
        speed=basespeed;
        points=0;
    }
    void Update()
    {
        rigibody.velocity = direction.normalized * speed;                   // описания полета шарика 
        if (transform.position.x > player.transform.position.x + 1)
        {
            Debug.Log("vi proigrali");
            Start();
        }
    }
    private void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            direction.x = -direction.x;
            speed=speed*coefficientspeed;
            points=points+1;
            Debug.Log("vi nabrali - " + points);
        }
         if(col.gameObject.CompareTag("TopWall"))
        {
            direction.y = -direction.y;
        }
         if(col.gameObject.CompareTag("BottomWall"))
        {
            direction.y = -direction.y;
        }
         if(col.gameObject.CompareTag("Sidewall"))
        {
             direction.x = -direction.x;
        }
 
    }
    }
