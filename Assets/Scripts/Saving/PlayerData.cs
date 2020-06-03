using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;

    public PlayerData(Player player)
    {
        position = new float[2];
        position[0] = player.transform.position.x - 2;
        position[1] = player.transform.position.y;
    }
}
