using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator animator;
    [SerializeField] float speed = 4f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    public Vector3 lastMotionVector3D;

    bool isSwinging = false;
    
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(
            horizontal,
            vertical
            );

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("isIdle", false);
            lastMotionVector = new Vector2(
                horizontal,
                vertical
                ).normalized;

            lastMotionVector3D = new Vector3(
                horizontal,
                vertical
                ).normalized;

            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
        else
        {
            animator.SetBool("isIdle", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isSwinging", true);
            isSwinging = true;
        }
        else
        {
            animator.SetBool("isSwinging", false);
        }


    }
    private void FixedUpdate()
    {      
        Move();
    }

    private void Move()
    {
        if (isSwinging)
        {
            rigidbody2d.velocity = motionVector * 0;
        }
        else
        {
            rigidbody2d.velocity = motionVector * speed;
        }   
    }

    void EndOfSwing()
    {
        isSwinging = false;
    }
}
