using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int sceneNumeber;

    public PlayerData(int number)
    {
        number = sceneNumeber = SceneManager.GetActiveScene().buildIndex;
    }
}
