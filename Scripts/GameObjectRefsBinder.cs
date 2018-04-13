using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GameObjectReferenceBinderData
{
    public int          GameObjectRefAssetDataIndex;
    public GameObject   ReferencedGameObject;
}

public class GameObjectRefsBinder : MonoBehaviour {

    public GameObjectReferenceAsset AssetRef;
    public GameObjectReferenceBinderData[] Bindings;

	private void Awake()
	{
		for (int i = 0; i < Bindings.Length; ++i)
		{
			GameObjectReferenceBinderData binding = Bindings[i];
			AssetRef.Datas[binding.GameObjectRefAssetDataIndex].TemporaryGameObjectReference = binding.ReferencedGameObject;
		}
	}
}
