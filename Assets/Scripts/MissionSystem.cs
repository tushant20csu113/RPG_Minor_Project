using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    public  List<MissionData> missions;

    public void ObjectSpawner(Vector3 pos,GameObject key)
    {
        Instantiate(key, pos, Quaternion.identity, transform);
    }
}
