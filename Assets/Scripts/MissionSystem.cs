using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    public  List<MissionData> missions;
    public static MissionSystem Instance { get;private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void ObjectSpawner(Vector3 pos,GameObject key)
    {
        Instantiate(key, pos, Quaternion.identity, transform);
    }
}
