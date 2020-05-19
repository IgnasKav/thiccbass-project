using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("2019-03-02");
        string path = Application.persistentDataPath + "/game_save.txt";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene("2019-03-02");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
