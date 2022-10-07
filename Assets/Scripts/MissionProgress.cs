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

    bool areKeysCollected;

    public static MissionProgress Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        keys.text = "Keys: " + keyCount;
        missionText = "Mission: " + MissionSystem.Instance.missions[0].missionName;
        TextUpdater(missionText);
    }

    public void TextUpdater(string missionText)
    {
        missionName.text = missionText;
    }
    void OnEnable()
    {
        Player.keyPickUp += Player_KeyCollected;
    }

    private void OnDisable()
    {
        Player.keyPickUp -= Player_KeyCollected;
    }

    private void Player_KeyCollected(string name)
    {
        if (name == "KeyPicked")
        {
            keyCount += 1;
            keys.text = "Keys: " + keyCount;
            if (keyCount == MissionSystem.Instance.missions[0].maxKeys && !areKeysCollected)
            {
                Vector3 playerPos = Player.Instance.transform.position;
                areKeysCollected = true;
                keyCount = 0;
                missionText = "Mission: Collect final key";
                TextUpdater(missionText);
                MissionSystem.Instance.ObjectSpawner(new Vector3(playerPos.x + 2, playerPos.y, playerPos.z + 2), MissionSystem.Instance.missions[0].finalKey);
            }
        }
    }
}
