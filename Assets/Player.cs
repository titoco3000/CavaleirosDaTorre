using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    string xInput = "Horizontal";
    string yInput = "Vertical";

    float speed = 60;
    float maxSpeed = 4;
    float downForce = 4;
    float maxSlidingVel = 1;

    float JumpForce = 300;
    float Height = 0.37f;
    float Width = 0.285f;
    public Vector2 WallJumpForce;

    public class Obstaculos
    {
        public bool Right { get; set; }
        public bool Left { get; set; }
        public bool Down { get; set; }

        public bool Lado()
        {
            if(Right || Left)
            {
                return true;
            }
            return false;
        }
    }

    public string Up;
    public string Down;
    public string Left;
    public string Right;
    public string Action;
    

    Rigidbody2D rb;
    public LayerMask groundLayer;
    Obstaculos obstaculo;

    bool moveEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        obstaculo = new Obstaculos();
        rb = GetComponent<Rigidbody2D>();    
    }


    // Update is called once per frame
    void Update()
    {
        //move
        if (moveEnabled)
        {
           rb.AddForce(new Vector2(speed * Input.GetAxis(xInput), 0));
        }
        //speed limit
        if(rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        else if(rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }

        if(obstaculo.Lado() && !obstaculo.Down ) //se wallSliding
        {
            if(rb.velocity.y < -maxSlidingVel)
            {
                rb.velocity = new Vector2(rb.velocity.x, -maxSlidingVel);
            }
        }
    }
    void FixedUpdate()
    {
        CheckObst();
        //Debug.Log("left: " + obstaculo.Left + " right: "+obstaculo.Right);
        if (Input.GetButton(yInput))
        {
            if(Input.GetAxis(yInput) > 0)
            {
                if (obstaculo.Lado())
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    moveEnabled = false;
                    Invoke("EnableMovement", .5f);
                    int lado = (obstaculo.Left ? 1 : -1);
                    rb.AddForce(new Vector2(WallJumpForce.x * lado, WallJumpForce.y))       ;
                }
                else if (obstaculo.Down)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(transform.up * JumpForce);
                }
            }
            else if(!obstaculo.Down)
            {
                rb.AddForce(-downForce * Vector2.up);
            }
        }
    }

    void Agir()
    {
        Debug.Log("acting!");
    }

    void EnableMovement()
    {
        moveEnabled = true;
    }

    void CheckObst()
    {
        //down
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Height, groundLayer);
        if(hit.collider != null)
        {
            obstaculo.Down = true;
        }
        else
        {
            obstaculo.Down = false;
        }

        //left
        hit = Physics2D.Raycast(transform.position, Vector2.left, Width, groundLayer);
        if (hit.collider != null)
            obstaculo.Left = true;
        else
            obstaculo.Left = false;

        //right
        hit = Physics2D.Raycast(transform.position, Vector2.right, Width, groundLayer);
        if (hit.collider != null)
            obstaculo.Right = true;
        else
            obstaculo.Right = false;
    }
}
