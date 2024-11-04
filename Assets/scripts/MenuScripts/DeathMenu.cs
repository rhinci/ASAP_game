using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void PlayPressed()   //переключение сцены на игру
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void ExitPressed() //выход из игры
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
