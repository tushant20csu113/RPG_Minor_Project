using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject[] walls; // 0 - Up 1 -Down 2 - Right 3- Left
    public GameObject[] doors;
    public List<Transform> spawnPoints;
   
    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            /*doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);*/
            doors[i].SetActive(true);
            walls[i].SetActive(false);
        }
    }
    public Vector3 SpawnPosition()
    {
        int index = Random.Range(0, spawnPoints.Count);
        return spawnPoints[index].position;
    }
}
