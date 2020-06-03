using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using System.IO;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckPointPosition;
    public PlayerPosition playerPosition;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            string path = Application.persistentDataPath + "/game_save.txt";
            if (File.Exists(path))
            {
                int data = SaveSystem.LoadPlayer();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
