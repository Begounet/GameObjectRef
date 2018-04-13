using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameObjectRefsBinder))]
public class GameObjectRefsBinderCustomEditor : Editor {
	
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GameObjectRefsBinder refBinder = (GameObjectRefsBinder)serializedObject.targetObject;

		EditorGUILayout.PropertyField(serializedObject.FindProperty("AssetRef"));

        if (refBinder.AssetRef != null)
		{
			SerializedProperty bindingProp = serializedObject.FindProperty("Bindings");
			bindingProp.isExpanded = EditorGUILayout.Foldout(bindingProp.isExpanded, "Bindings");

			if (bindingProp.isExpanded)
			{
				++EditorGUI.indentLevel;
				{
					bindingProp.arraySize = Mathf.Max(0, EditorGUILayout.IntField("Size", bindingProp.arraySize));

					string[] referenceNames = refBinder.AssetRef.GetReferenceNames();

					if (referenceNames != null)
					{
						for (int i = 0; i < bindingProp.arraySize; ++i)
						{
							SerializedProperty bindingElementProp = bindingProp.GetArrayElementAtIndex(i);
							DrawReferenceBinderData(referenceNames, bindingElementProp);
						}
					}
					else
					{
						EditorGUILayout.LabelField("You must had reference names in the " + refBinder.AssetRef.name + " asset !");
					}
				}
				--EditorGUI.indentLevel;
            }
        }

        serializedObject.ApplyModifiedProperties(); 
    }

    private GameObjectReferenceBinderData[] ResizeArray(GameObjectReferenceBinderData[] datas, int newSize)
    {
        GameObjectReferenceBinderData[] newDatas = new GameObjectReferenceBinderData[newSize];

		int start = 0;
		if (datas != null)
		{
			for (; start < newSize && start < datas.Length; ++start)
			{
				newDatas[start] = datas[start];
			}
		}

		for (; start < newSize; ++start)
		{
			newDatas[start] = new GameObjectReferenceBinderData();
		}

        return (newDatas);
    }

	public void  DrawReferenceBinderData(string[] referenceNames, SerializedProperty bindingElementProp)
    {
        EditorGUILayout.BeginHorizontal(); 
        {
			{ 
				SerializedProperty gameObjectRefAssetDataIndexProp = bindingElementProp.FindPropertyRelative("GameObjectRefAssetDataIndex");
				gameObjectRefAssetDataIndexProp.intValue = EditorGUILayout.Popup(gameObjectRefAssetDataIndexProp.intValue, referenceNames);
			}
			{
				SerializedProperty referencedGameObjectProp = bindingElementProp.FindPropertyRelative("ReferencedGameObject");
				referencedGameObjectProp.objectReferenceValue = EditorGUILayout.ObjectField(referencedGameObjectProp.objectReferenceValue, typeof(GameObject), true);
			}
        }
        EditorGUILayout.EndHorizontal();
    }
}
