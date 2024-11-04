using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health;

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("DeathMenu");
        }
    }
}
