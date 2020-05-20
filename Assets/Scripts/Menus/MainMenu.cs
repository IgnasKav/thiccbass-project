using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("ForestLevel");
        string path = Application.persistentDataPath + "/game_save.txt";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene("ForestLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
