using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int current_health;
    public int max_health;

    public void ChangeHealth(int health)
    {
        current_health += health;

        if (current_health > max_health)
        {
            current_health = max_health;
        } else if (current_health <= 0)
        {
            Debug.Log("DEATH");
        }
    }
}
