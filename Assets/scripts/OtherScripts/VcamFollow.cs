using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NVcamFollow : MonoBehaviour
{
    public Transform Player1, Player2;
    public GameObject Player1obj;
    private CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    { 

        switch (Player1obj.activeSelf)
        {
            case true:
                vcam.Follow = Player1;
                break;
            case false:
                vcam.Follow = Player2;
                break;
        }
    }
}
