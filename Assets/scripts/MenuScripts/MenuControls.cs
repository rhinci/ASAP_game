using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void PlayPressed()   //переключение сцены на игру
    {
        SceneManager.LoadScene("Story");
    }

    public void ExitPressed() //выход из игры
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}