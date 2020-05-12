﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontStopAudio : MonoBehaviour
{
    public static DontStopAudio musicPlay;
    public bool Always;

    void Awake()
    {
        if (musicPlay == null)
        {
            DontDestroyOnLoad(gameObject);
            musicPlay = this;
        }
        else if (musicPlay != this)
        {
            Destroy(gameObject);
        }
    }
}