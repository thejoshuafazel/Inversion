using UnityEngine;

public class WorldSettings : MonoBehaviour
{
    public WORLD_TYPE _worldType;

    public WORLD_TYPE WorldType { get { return _worldType; } set { _worldType = value; } }

}
