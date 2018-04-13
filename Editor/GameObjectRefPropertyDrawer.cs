using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GameObjectRef))]
public class GameObjectRefPropertyDrawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		position = EditorGUI.PrefixLabel(position, label);

		SerializedProperty refAssetProp = property.FindPropertyRelative("RefsAsset");

		float midWidth = position.width / 2;

		if (refAssetProp.objectReferenceValue != null)
		{
			position.width = midWidth;
		}

		EditorGUI.PropertyField(position, property.FindPropertyRelative("RefsAsset"), new GUIContent(""));

		if (refAssetProp.objectReferenceValue != null)
		{
			position.x += midWidth;

			SerializedProperty gameObjectBoundIndexProp = property.FindPropertyRelative("GameObjectBoundIndex");
			GameObjectReferenceAsset refAsset = (GameObjectReferenceAsset) refAssetProp.objectReferenceValue;
			gameObjectBoundIndexProp.intValue = EditorGUI.Popup(position, gameObjectBoundIndexProp.intValue, refAsset.GetReferenceNames());
		}
	}
}
