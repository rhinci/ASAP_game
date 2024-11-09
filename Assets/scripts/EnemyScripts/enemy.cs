using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int health;
    public float speed;
    public int damage;
    public int positionOfPatrol;
    public Transform point;
    public float stoppingDistance;

    public GameObject Player1, Player2;
    private GameObject ActivePlayer;

    public GameObject player;
    private Animator anim;
    private Transform target;
    private bool facingLeft;

    bool chill = false;
    bool angry = false;
    bool goBack = false;

    private void Start()
    {
        facingLeft = true;
        anim = GetComponent<Animator>();
        switch (Player1.activeInHierarchy)
        {
            case true:
                ActivePlayer = Player1;
                break;
            case false:
                ActivePlayer = Player2;
                break;


        }
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

        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, ActivePlayer.GetComponent<Transform>().position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, ActivePlayer.GetComponent<Transform>().position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

       
        target = ActivePlayer.GetComponent<Transform>();

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            GoBack();
        }
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

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void OnEnemyAttack()
    {
        player.GetComponent<Player>().health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            Flip();
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            Flip();
        }

        if (facingLeft ==  false)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);

        // Вычисляем направление к игроку
        Vector2 direction = target.position - transform.position;
        Debug.Log(direction);

        // Если игрок находится справа от врага
        if (direction.x > 0 && facingLeft == true)
        {
            Flip();
        }
        else if (direction.x < 0 && facingLeft == false)
        {
            Flip();
        }
    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.fixedDeltaTime);
    }
}
