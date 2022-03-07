using System;
using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int _rounds = 6;
    private AudioManager _audioManager;
    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
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
        if (_rounds - 1 < 0)
        {
            _audioManager.Play("GunEmpty");
            return;
        }
        _rounds -= 1;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction * Vector2.right);
        if (hit.collider != null)
        {
            float distance = Math.Abs(hit.point.x - transform.position.x);
            if (distance <= 20)
            {
                hit.collider.GetComponent<Monster>().Die();
            }
        }
        _audioManager.Play("Gunshot");
    }
}
