using UnityEngine;

public class Respawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LevelLoader>().RestartLevel();
    }
}
