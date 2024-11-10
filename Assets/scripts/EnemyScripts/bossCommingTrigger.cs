using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCommingTrigger : MonoBehaviour
{
    public GameObject boss;
    private Animator anim;
    public GameObject hearts;

    private void Start()
    {
        boss.SetActive(false);
        hearts.SetActive(false);
        anim = boss.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        boss.SetActive(true);
        hearts.SetActive(true);
        anim.SetTrigger("isComming");
    }
}
