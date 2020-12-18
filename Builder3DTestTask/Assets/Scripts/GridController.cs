using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridGenerator))]
public class TreeGeneratorController : Editor
{

    GridGenerator TG;

    private void OnEnable()
    {

        TG = (GridGenerator)target;

    }

    override public void OnInspectorGUI()
    {

        DrawDefaultInspector();

        if (GUILayout.Button("Apply"))
        {

            TG.GenerateGrid();

        }

    }

}