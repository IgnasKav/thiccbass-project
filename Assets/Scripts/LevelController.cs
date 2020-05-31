﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int enemyCount;

    public void AddEnemy() {
        enemyCount++;
    }

    public void RemoveEnemy() {
        enemyCount--;
    }

    public bool ObjectiveComplete() {
        return enemyCount == 0;
    }
}