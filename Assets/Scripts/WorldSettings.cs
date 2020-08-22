using UnityEngine;

public class WorldSettings : MonoBehaviour
{
    [SerializeField] WORLD_TYPE _worldType;

    public WORLD_TYPE WorldType
    { 
        get { 
            return _worldType; 
        }
    }

}
