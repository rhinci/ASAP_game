using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class storyMenu : MonoBehaviour
{
    public GameObject sc1;
    public GameObject sc2;
    public GameObject sc3;
    public GameObject sc4;
    public GameObject sc5;
    public GameObject sc6;

    public void to2()
    {
        sc1.SetActive(false);
        sc2.SetActive(true);
    }

    public void to3()
    {
        sc2.SetActive(false);
        sc3.SetActive(true);
    }
    public void to4()
    {
        sc3.SetActive(false);
        sc4.SetActive(true);
    }
    public void to5()
    {
        sc4.SetActive(false);
        sc5.SetActive(true);
    }
    public void to6()
    {
        sc5.SetActive(false);
        sc6.SetActive(true);
    }
    public void Exit()
    {
        SceneManager.LoadScene("FirstScene");
    }
}
