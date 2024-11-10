using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateTrigger : MonoBehaviour
{
    public GameObject Player1, Player2;
    public GameObject tipTable;
    private Animator anim;

    private void Start()
    {
        anim = tipTable.GetComponent<Animator>();
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
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
    public void OnTriggerExit2D(Collider2D other)
    {
        anim.SetInteger("state", 0);
    }
}
