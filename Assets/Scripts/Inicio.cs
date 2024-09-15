using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    public void jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void menu()
    {
        Time.timeScale = 1.0f;
        Player.SCORE = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1.0f;
        Player.SCORE = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
