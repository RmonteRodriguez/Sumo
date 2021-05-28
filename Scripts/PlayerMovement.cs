using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Shake shake;

    public float speed;
    public float jumpForce;
    private float moveInput;

    public bool isSingle;

    private Rigidbody2D rb;

    public Transform spawner;


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    public GameObject player;
    public GameObject deathEffects;
    public GameObject endGame;

    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Transform>();
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        if(Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Death();
        }
    }

    public void Death()
    {
        Instantiate(deathEffects, transform.position, Quaternion.identity);
        shake.CamShake();

        if (isSingle)
        {
            endGame.SetActive(true);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(player, spawner.position, spawner.rotation);
        }
    }
}
