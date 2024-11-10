using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateTrigger : MonoBehaviour
{
    public GameObject Player1, Player2;
    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Player1.GetComponent<PlayerController>().activated = true;
            Player2.GetComponent<PlayerController>().activated = true;
            GetComponent<TipsTrigger>().message = "Нажмите [E], чтобы трансформироваться и [ЛКМ] для атаки.\r\nСлушай зов дикой души и обращайся в чудесных зверей. Их силы помогут тебе";
            TipsManager.displayTipEvent?.Invoke(GetComponent<TipsTrigger>().message);
        }
    }
}
