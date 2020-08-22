using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator _transition;
    [SerializeField] float _transitionTime = 1.0f;

    public void LoadNextLevel()
    {
        int sceneToLoad = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        LoadScene(sceneToLoad);
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadLevel(sceneIndex));
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }

    public void RestartLevel()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        LoadScene(0);
    }

    public void LoadOptions()
    {
        LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
