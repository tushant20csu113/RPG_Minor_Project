using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    public List<MissionData> missions; 
    // Start is called before the first frame update
    void Start()
    {

        //Instantiate(missions[0].keys, new Vector3(0,0,0), Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ObjectSpawner(Vector3 pos)
    {
        Instantiate(missions[0].keys, pos, Quaternion.identity, transform);
    }
}
