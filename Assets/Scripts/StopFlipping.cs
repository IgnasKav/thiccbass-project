using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFlipping : MonoBehaviour
{
    private Vector3 scale;
    void Awake()
    {
        scale = transform.localScale;
    }
    void FixedUpdate()
  {
        transform.localScale = scale;
  }
}
