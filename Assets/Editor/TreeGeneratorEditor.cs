using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Redenrizacao3D))]
public class TreeGeneratorEditor : Editor {

    public override void OnInspectorGUI()
    {
        Redenrizacao3D tree = (Redenrizacao3D)target;

        // If inspector is changed
        if(DrawDefaultInspector())
        {
            tree.GenerateTree();
        }

        if (GUILayout.Button("Generate Tree"))
        {
            tree.GenerateTree();
        }
    }
}
