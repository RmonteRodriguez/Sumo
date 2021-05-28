using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumoAI : MonoBehaviour
{
    public GameManager gameManager;
    public EndlessSpawners endlessSpawners;
    private Shake shake;

    public float speed;
    public float jumpForce;
    public Transform target;

    public string follow;

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    public GameObject deathEffects;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(follow).GetComponent<Transform>();
        endlessSpawners = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EndlessSpawners>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
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
        Destroy(gameObject);
        endlessSpawners.SpawnEnemy();
        shake.CamShake();
    }
}
