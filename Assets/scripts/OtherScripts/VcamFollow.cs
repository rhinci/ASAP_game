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
        Debug.Log(Player1obj.activeSelf);
        if (Player1obj.activeSelf == true)
        {
            vcam.Follow = Player1;
        } else
        {
            vcam.Follow = Player2;
        }
    }
}
