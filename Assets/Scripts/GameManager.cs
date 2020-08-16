using UnityEngine;

public enum WORLD_TYPE { WHITE, BLACK }

public class GameManager : MonoBehaviour
{
    public WORLD_TYPE _startingWorld;
    public GameObject[] _worlds;

    private int _currentWorldIndex;

    private void Awake()
    {
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
            }
            else
            {
                worldGrid.SetActive(false);
            }
        }
    }

    public void LoadNextWorld()
    {
        _currentWorldIndex = (_currentWorldIndex + 1) % _worlds.Length;
        WORLD_TYPE worldToLoad = _worlds[_currentWorldIndex].GetComponent<WorldSettings>().worldType;
        WorldSwitcher(worldToLoad);
    }
}
