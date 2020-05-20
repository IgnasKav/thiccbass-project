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
                PlayerData data = SaveSystem.LoadPlayer();
                Vector2 position;
                position.x = data.position[0] - 2;
                position.y = data.position[1];
                lastCheckPointPosition = position;
            }
        }
        else
        {
            Destroy(gameObject);
            Vector2 position;
            position.x = -8f;
            position.y = 0.55f;
            lastCheckPointPosition = position;
        }
    }
}
