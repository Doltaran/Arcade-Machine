using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelName; // Имя сцены для загрузки       
    public void PlayGame()
    {
        SceneManager.LoadScene(levelName);
    }

    void OnTriggerEnter2D(Collider2D myCollider)
    {
        if (myCollider.tag == "Player")
        {
            SceneManager.LoadScene(levelName);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Игра закрылась");
    }
}
