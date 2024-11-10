using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bossHearts : MonoBehaviour
{
    public float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float heal;


    private void Start()
    {
        health = GetComponent<wall>().health;
    }
    private void Update()
    {
        health = GetComponent<wall>().health;
        if (health <= 0)
        {
            SceneManager.LoadScene("DeathMenu");
        }
    }

    private void FixedUpdate()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        health += Time.deltaTime * heal;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
