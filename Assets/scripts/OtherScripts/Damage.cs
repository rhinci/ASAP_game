using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public string[] TAGS;

    public void OnTriggerEnter(Collider gameobject)
    {
        if (TAGS != null)
        {
            for (int i = 0; i < TAGS.Length; i++)
            {
                if (gameobject.tag == TAGS[i])
                {
                    gameobject.GetComponent<Health>().ChangeHealth(damage);
                }
            }
        }
    }
}