using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.ComponentModel;

public static class SaveSystem
{
    public static void SavePlayer ()
    {
        int data = SceneManager.GetActiveScene().buildIndex;

        string line = $"{data}";

        string path = Application.persistentDataPath + "/game_save.txt";
        using (StreamWriter outputFile = new StreamWriter(path))
        {
            outputFile.WriteLine(line);
            UnityEngine.Debug.Log(line);
        }
    }

    public static int LoadPlayer()
    {
        string path = Application.persistentDataPath + "/game_save.txt";
        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            int data = 0;

            while ((line = sr.ReadLine()) != null)
            {
                 data = Convert.ToInt32(line);
                UnityEngine.Debug.Log(data);
            }

            return data;
        }
    }
}