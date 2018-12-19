using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Christian : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator anim;

    public int health;
    private float dazedTime;
    public float startDazedTime;



    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(up) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
        }
        else if (theRB.velocity.x < 0)

        {
            transform.localScale = new Vector3(-1.6f, 1.6f, 1.6f);
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
        if(dazedTime <= 0)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2(0, 0);
            dazedTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            SceneManager.LoadScene(2);
        }
        

    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("hurt");
        health -= damage;
    }
}
