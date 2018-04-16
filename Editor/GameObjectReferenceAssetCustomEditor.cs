using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(GameObjectReferenceAsset))]
public class GameObjectReferenceAssetCustomEditor : Editor {

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        {
            EditorGUILayout.HelpBox("Set the name of your references here", MessageType.Info);

            SerializedProperty datasArrayProp = serializedObject.FindProperty("Datas");
            datasArrayProp.arraySize = Mathf.Max(0, EditorGUILayout.IntField("Number of references", datasArrayProp.arraySize));

            for (int i = 0; i < datasArrayProp.arraySize; ++i)
            {
                EditorGUILayout.BeginHorizontal();
                {
                    // Prefix
                    EditorGUILayout.PrefixLabel("Reference #" + i);

                    // Reference name text field
                    SerializedProperty dataElementProp = datasArrayProp.GetArrayElementAtIndex(i);
                    SerializedProperty referenceNameProp = dataElementProp.FindPropertyRelative("ReferenceName");
                    referenceNameProp.stringValue = EditorGUILayout.TextField(referenceNameProp.stringValue);
                }
                EditorGUILayout.EndHorizontal();
            }
        }
        serializedObject.ApplyModifiedProperties();
    }

}
