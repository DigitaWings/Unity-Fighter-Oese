using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Esben : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;

    public int health;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator anim;


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

       if(theRB.velocity.x > 0)
      {
          transform.localScale = new Vector3(-2, 2, 2);
       }   else if(theRB.velocity.x < 0)

       {
            transform.localScale = new Vector3(2, 2, 2);
       }
       
        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);

        if(health <= 0)
        {
            SceneManager.LoadScene("Scenes/christianwins");
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("EsbenDamageTaken");
        anim.SetTrigger("hurt");
        anim.ResetTrigger("hurt");
        health -= damage;
    }

}
