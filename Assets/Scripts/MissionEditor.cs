using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MissionEditor : EditorWindow
{
    string missionName;
    //GameObject[] keys;
    GameObject normalKey;
    GameObject finalKey;
    
    int maxKeys;
  
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
        normalKey =(GameObject)EditorGUILayout.ObjectField("Normal Keys", normalKey, typeof(GameObject), true);
        finalKey = (GameObject)EditorGUILayout.ObjectField("Final Key", finalKey, typeof(GameObject), true);
        maxKeys=(int)EditorGUILayout.IntField("Number of keys to be collected: ", maxKeys);
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
            missionData.keys = normalKey;
            missionData.finalKey = finalKey;
            missionData.maxKeys = maxKeys;
            AssetDatabase.CreateAsset(missionData, "Assets/Missions/MissionData/" + missionName + ".asset");
            AssetDatabase.SaveAssets();
        }
    }
}
