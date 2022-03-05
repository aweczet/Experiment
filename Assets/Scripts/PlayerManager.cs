using System;
using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Player started");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Shoot(-1);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Shoot(1);
        }
    }

    private void Shoot(float direction)
    {
        Debug.Log(direction < 0 ? "Left arrow pressed" : "Right arrow pressed");
    }
}
