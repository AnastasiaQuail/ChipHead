using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletMove : MonoBehaviour {

    bool facingRight = true;
    public LayerMask player;
    public float move_speed=5f;
    public bool EndTrip = false;
    private Animator _animator;
    public Vector2 direction; 
    void Start()
    {
        _animator = GetComponent<Animator>();
        //Ray2D ray = new Ray2D(GetComponent<Rigidbody2D>().position, GetComponent<Rigidbody2D>().transform.forward);
        
    }

    void Update()
    {

        if (move_speed > 0 && !facingRight)
            Flip();
        else if (move_speed < 0 && facingRight)
        {
            Flip();

        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(move_speed, 0);

        RaycastHit2D hit = Physics2D.Raycast(GetComponent<Rigidbody2D>().transform.position, -GetComponent<Rigidbody2D>().transform.right, 100.0f, player);

        //If something was hit.
        if (hit.transform.tag == "pers")
        {
            Transform objectHit = hit.transform;

            //Display the name of the parent of the object hit.
            Debug.Log(objectHit.name);

        }
    }
   

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        var isTheSameParent = this.transform.parent == col.transform.parent;
        if (isTheSameParent)
        {
            move_speed = move_speed * -1;
        }

    }
}