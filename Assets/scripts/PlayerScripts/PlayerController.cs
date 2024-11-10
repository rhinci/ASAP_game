using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;
    public bool activated = false;

    private bool isGrounded;
    public Transform feetpos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;

    public GameObject players;
    public GameObject trans;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        trans.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOf");
        }

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
        if (Input.GetKeyDown(KeyCode.E) && activated == true)
        {
            trans.transform.position = transform.position;
            trans.gameObject.SetActive(true);
            StartCoroutine(DeactivateAfterTime(0.25f));
            Invoke("Switch", 0.3f);

        }
    }

    private void Switch()
    {
        players.GetComponent<switcher>().SwitchCharacter();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private IEnumerator DeactivateAfterTime(float time)
    {
        // Ждем указанное время
        yield return new WaitForSeconds(time);

        // Деактивируем объект
        trans.SetActive(false);
    }
}