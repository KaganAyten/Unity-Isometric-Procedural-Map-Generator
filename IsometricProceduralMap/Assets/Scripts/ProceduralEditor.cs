using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ProceduralIsometricMap))]
public class ProceduralEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ProceduralIsometricMap myTarget = (ProceduralIsometricMap)target;

        if (GUILayout.Button("Create Map"))
        {
            myTarget.GenerateMap();
        }
        if (GUILayout.Button("Clear Map"))
        {
            myTarget.ClearMap();
        }
        if (GUILayout.Button("Save Map"))
        {
            myTarget.SaveAsPrefab();
        }
    }
}
