using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCleared : MonoBehaviour
{
    private LevelLoader _levelLoader;

    private void Awake()
    {
        _levelLoader = FindObjectOfType<LevelLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _levelLoader.LoadNextLevel();
    }
}
