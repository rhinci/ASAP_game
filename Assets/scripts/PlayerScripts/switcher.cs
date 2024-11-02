using System;
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class switcher : MonoBehaviour
{
    public GameObject Player1, Player2;

    int charOn = 1;

    void Start()
    {
        Player1.gameObject.SetActive(true);
        Player2.gameObject.SetActive(false);

    }

    public void SwitchCharacter()
    {

        switch (charOn)
        {

            case 1:
                charOn = 2;

                Player1.gameObject.SetActive(false);
                Player2.gameObject.SetActive(true);
                Player2.transform.position = Player1.transform.position;
                break;
            case 2:
                charOn = 1;
                Player1.gameObject.SetActive(true);
                Player2.gameObject.SetActive(false);
                Player1.transform.position = Player2.transform.position;
                break;
        }
    }
}

