using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSettings : MonoBehaviour
{
    public WORLD_TYPE worldType;

    public WORLD_TYPE WorldType { get { return worldType; } set { worldType = value; } }

}
