using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class MainMenu : MonoBehaviour
{
    public LevelLoader levelLoader;

    public void PlayGame()
    {
        levelLoader.LoadNextLevel();
        string path = Application.persistentDataPath + "/game_save.txt";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public void ResumeGame()
    {
        string path = Application.persistentDataPath + "/game_save.txt";
        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            int data = 0;

            while ((line = sr.ReadLine()) != null)
            {
                data = Convert.ToInt32(line);
            }

            UnityEngine.Debug.Log(data);
            levelLoader.LoadNextLevel(data);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
