using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float maxSpeed;
    private float jumpPower;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private void Awake()
    {
        maxSpeed = 1.5f;
        jumpPower = 8.0f;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            anim.SetBool("isJumping", true);
            rigid.AddForce(0.5f * Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        if (Mathf.Abs(rigid.velocity.x) < 0.01f)
        {
            anim.SetBool("isRunning", false);
        }   
        else
        {
            anim.SetBool("isRunning", true);
        }

        // Landing Platform
        if (rigid.velocity.y <= 0)
        {
            Debug.DrawRay(rigid.position, 0.3f * Vector3.down, new Color(0, 1.0f, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, 0.3f * Vector3.down, 1, LayerMask.GetMask("Floor"));

            if (rayHit.collider != null)
            {
                Debug.Log(rayHit.distance);
                if (rayHit.distance < 0.22f)
                    anim.SetBool("isJumping", false);
            }
        }
    }

    private void FixedUpdate()
    {
        // Accelerate by key control
        float direction = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(0.5f * Vector2.right * direction, ForceMode2D.Impulse);

        // Speed limitation
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < -maxSpeed)
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
    }
}
