using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int health;
    public float speed;
    public int damage;
    public float attackRange;

    public GameObject Player1, Player2;
    private GameObject ActivePlayer;

    private Player player;
    private Animator anim;
    private Transform target;
    private bool facingLeft;

    private void Start()
    {
        facingLeft = true;
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }


    private void Update()
    {
        switch (Player1.activeInHierarchy)
        {
            case true:
                ActivePlayer = Player1;
                break;
            case false:
                ActivePlayer = Player2;
                break;


        }
        target = ActivePlayer.GetComponent<Transform>();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        //transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Вычисляем направление к игроку
        Vector2 direction = target.position - transform.position;
        Debug.Log(direction);

        // Если игрок находится справа от врага
        if (direction.x > 0 && facingLeft == true)
        {
            // Отзеркаливаем врага
            Flip();

        }
        else if (direction.x < 0 && facingLeft == false)
        {
            Flip();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(timeBtwAttack <= 0)
            {
                anim.SetTrigger("enemyAttack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public void OnEnemyAttack()
    {
        player.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
