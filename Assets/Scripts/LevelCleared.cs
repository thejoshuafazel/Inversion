using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCleared : MonoBehaviour
{
    private LevelLoader _levelLoader;

    private void Awake()
    {
        _levelLoader = FindObjectOfType<LevelLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int sceneToLoad = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        _levelLoader.LoadScene(sceneToLoad);
    }
}
