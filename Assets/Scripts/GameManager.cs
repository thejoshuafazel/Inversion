using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum WORLD_TYPE { WHITE, BLACK}

public class GameManager : MonoBehaviour
{
    public bool startWorldIsBlack;
    public GameObject[] worldGrids;

    private WORLD_TYPE currentWorld;

    private void Awake() {
        if (startWorldIsBlack) {
            currentWorld = WORLD_TYPE.BLACK;
        } else {
            currentWorld = WORLD_TYPE.WHITE;
        }
        WorldSwitcher(currentWorld);
    }

    public void WorldSwitcher(WORLD_TYPE worldToLoad) {
        foreach (GameObject worldGrid in worldGrids) {
            if (worldGrid.GetComponent<WorldSettings>().WorldType == worldToLoad) {
                worldGrid.SetActive(true);
            } else { worldGrid.SetActive(false); }
        }
        currentWorld = worldToLoad;
    }

    public WORLD_TYPE NextWorld() {
        int worldID = (int)currentWorld;
        int worldIDCount = Enum.GetNames(typeof(WORLD_TYPE)).Length;

        if (worldID == worldIDCount - 1) {
            WorldSwitcher((WORLD_TYPE)0);
            return (WORLD_TYPE)0;
        }
        WorldSwitcher((WORLD_TYPE)worldID + 1);
        return (WORLD_TYPE)worldID + 1;
    }
}
