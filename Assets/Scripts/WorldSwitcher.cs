using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    private GameManager _gameManager;
    private AudioSource _audioSource;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _gameManager.LoadNextWorld();
            _audioSource.Play();
        }
    }
}
