using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour {

    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    bool facingRight = true;

    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public bool swing = false;
    int swingForce = 25;
    bool canSwing = true;

    //bool pullAvaliable = false;
    //public LayerMask Pull;
    //public Transform pullCheck;
    //public float pullRadius = 0.5f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start ()
    {
	    	
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (swing == false)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        }
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }


        
	}


    void Update()
    {

       

        if (grounded && ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) || Input.GetKeyDown(KeyCode.Joystick1Button0)))
        {
            if (swing == false)
            {
                rb.AddForce(new Vector2(0, jumpForce));
            }
            if(swing==true)
            {
                swing = false;
                Destroy(GetComponent<HingeJoint2D>());
                rb.AddForce(new Vector2(0, jumpForce));
                
                StartCoroutine(Wait());


            }
        }
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        
        

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Rope" && canSwing == true)
        {
            grounded = true;
            canSwing = false;
            swing = true;
            GetComponent<CapsuleCollider2D>().enabled = false;
            HingeJoint2D hinge = gameObject.AddComponent<HingeJoint2D>() as HingeJoint2D;
            hinge.connectedBody = other.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);
        canSwing = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
    }

   

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
