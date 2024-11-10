using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateTrigger : MonoBehaviour
{
    public GameObject Player1, Player2;
    public GameObject firstTip, SecTip;
    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Player1.GetComponent<PlayerController>().activated = true;
            Player2.GetComponent<PlayerController>().activated = true;
            firstTip.gameObject.SetActive(false);
            SecTip.gameObject.SetActive(true);
        }
    }
}
