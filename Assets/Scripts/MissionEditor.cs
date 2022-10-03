using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MissionEditor : EditorWindow
{
    string missionName;
    //GameObject[] keys;
    GameObject finalKey;
  
    [MenuItem("RPG/Escape Room/Mission Info")]
    static void OpenWindow()
    {
        MissionEditor myWindow = (MissionEditor)GetWindow(typeof(MissionEditor));
        myWindow.Show();
   
    }
    private void OnGUI()
    {
        
        GUILayout.Label("This is a mission editor window.");
        missionName = EditorGUILayout.TextField("Mission Name", missionName);
        finalKey=(GameObject)EditorGUILayout.ObjectField("Keys", finalKey, typeof(GameObject), true);
       /* for (int i = 0; i < keys.Length; i++)
        {
            keys[i] = (GameObject)EditorGUILayout.ObjectField("Keys", keys[i], typeof(GameObject), true);
        }*/
        if (GUILayout.Button("Create Mission"))
        {
            MissionData missionData = ScriptableObject.CreateInstance<MissionData>();
            missionData.missionName = missionName;
            /*for (int i = 0; i < keys.Length; i++)
            {
                missionData.keys[i] = keys[i];
            }*/
            missionData.keys = finalKey;
            //car.carImage = carImage;
            AssetDatabase.CreateAsset(missionData, "Assets/Missions/MissionData/" + missionName + ".asset");
            AssetDatabase.SaveAssets();
        }
    }
}
