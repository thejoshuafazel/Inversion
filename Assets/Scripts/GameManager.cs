using UnityEngine;
using UnityEngine.UI;

public enum WORLD_TYPE { WHITE, BLACK }

public class GameManager : MonoBehaviour
{
    [SerializeField] WORLD_TYPE _startingWorld;
    [SerializeField] GameObject[] _worlds;
    [SerializeField] Sprite[] _transitionSprites;
    [SerializeField] bool _randomizeStartWorld;

    private int _currentWorldIndex;
    private Image _circleWipeImage;

    private void Start()
    {
        _circleWipeImage = FindObjectOfType<CircleWipe>().gameObject.GetComponent<Image>();
        _startingWorld = _randomizeStartWorld ? (WORLD_TYPE)Random.Range(0, _worlds.Length) : _startingWorld;
        WorldSwitcher(_startingWorld);
    }

    private void WorldSwitcher(WORLD_TYPE worldToLoad)
    {
        for (int worldNumber = 0; worldNumber < _worlds.Length; worldNumber++)
        {
            GameObject worldGrid = _worlds[worldNumber];
            WorldSettings worldSetting = worldGrid.GetComponent<WorldSettings>();
            if (worldSetting.WorldType == worldToLoad)
            {
                worldGrid.SetActive(true);
                _currentWorldIndex = worldNumber;
                UpdateTransitionImage();
            }
            else
            {
                worldGrid.SetActive(false);
            }
        }
    }

    private void UpdateTransitionImage()
    {
        _circleWipeImage.sprite = _transitionSprites[_currentWorldIndex];
    }

    public void LoadNextWorld()
    {
        _currentWorldIndex = (_currentWorldIndex + 1) % _worlds.Length;
        WORLD_TYPE worldToLoad = _worlds[_currentWorldIndex].GetComponent<WorldSettings>()._worldType;
        WorldSwitcher(worldToLoad);
    }
}
