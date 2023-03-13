using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(SpliceSpriteController))]
public class SpliceEditor : Editor {

    public override void OnInspectorGUI()
    {
        SpliceSpriteController myTarget = (SpliceSpriteController)target;
      

        myTarget.fragmentLayer = EditorGUILayout.TextField("Fragment Layer", myTarget.fragmentLayer);
        myTarget.sortingLayerName = EditorGUILayout.TextField("Sorting Layer", myTarget.sortingLayerName);
        myTarget.orderInLayer = EditorGUILayout.IntField("Order In Layer", myTarget.orderInLayer);
        
        if (myTarget.GetComponent<PolygonCollider2D>() == null && myTarget.GetComponent<BoxCollider2D>() == null)
        {
            EditorGUILayout.HelpBox("You must add a BoxCollider2D or PolygonCollider2D to explode this sprite", MessageType.Warning);
        }
        else
        {
            if (GUILayout.Button("Generate Fragments"))
            {
                myTarget.fragmentInEditor();
                EditorUtility.SetDirty(myTarget);
            }
            if (GUILayout.Button("Destroy Fragments"))
            {
                myTarget.deleteFragments();
                EditorUtility.SetDirty(myTarget);
            }
        }
        
    }
}
