using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed = 6.0f;

    void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }
}
