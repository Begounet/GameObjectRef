using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameObjectReferenceAsset")]
public class GameObjectReferenceAsset : ScriptableObject {  
   
	[System.Serializable]
	public class GoRefAssetDatas
	{
		public string ReferenceName;

		[HideInInspector]
		public GameObject TemporaryGameObjectReference;
	}

	public GoRefAssetDatas[] Datas;

	public string[]	GetReferenceNames()
	{
		if (Datas != null && Datas.Length > 0)
		{
			string[] refNames = new string[Datas.Length];

			for (int i = 0; i < Datas.Length; ++i)
			{
				refNames[i] = Datas[i].ReferenceName;
			}

			return (refNames);
		}

		return (null);
	}
}
