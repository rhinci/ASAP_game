using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class cameraTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public float LensSize;

    private void Start()
    {
        //vcam = GetComponent<CinemachineVirtualCamera>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag == "Player")
       {
            vcam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = LensSize;
            vcam.GetComponent<CinemachineConfiner2D>().m_Padding += 0.1f;
       }
    }

}
