using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    private GameManager _gameManager;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _gameManager.LoadNextWorld();
        }
    }
}
