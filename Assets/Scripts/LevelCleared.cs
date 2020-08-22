using UnityEngine;

public class LevelCleared : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }
}
