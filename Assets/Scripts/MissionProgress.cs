using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionProgress : MonoBehaviour
{
    public TextMeshProUGUI keys;
    public TextMeshProUGUI missionName;
    public static int keyCount;
    public static string missionText;
    public MissionSystem mObject;
    bool areKeysCollected;
    public Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        keys.text = "Keys: " + keyCount;
        missionText = mObject.missions[0].missionName;
        missionName.text = "Mission: "+missionText;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerPosition.position;
        keys.text = "Keys: " + keyCount;
        if (keyCount== mObject.missions[0].maxKeys && !areKeysCollected)
        {
            areKeysCollected = true;
            keyCount = 0;
            missionText = "Mission: Collect final key";
            missionName.text=missionText;
            mObject.ObjectSpawner(new Vector3(playerPos.x+2, playerPos.y, playerPos.z+2), mObject.missions[0].finalKey);
        }
    }
}
