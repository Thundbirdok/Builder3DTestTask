using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridGenerator))]
public class GridGeneratorEditor : Editor
{

    GridGenerator GG;

    private void OnEnable()
    {

        GG = (GridGenerator)target;

    }

    override public void OnInspectorGUI()
    {

        DrawDefaultInspector();

        if (GUILayout.Button("Apply"))
        {

            GG.GenerateGrid();

        }

    }

}