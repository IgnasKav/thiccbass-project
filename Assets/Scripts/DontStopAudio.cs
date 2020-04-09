using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontStopAudio : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
