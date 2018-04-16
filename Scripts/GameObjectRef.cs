using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameObjectRef
{
    public GameObjectReferenceAsset RefsAsset;
    public int GameObjectBoundIndex;

    private GameObject GameObjectCache;
    
    public GameObject Get()
    {
        if (GameObjectCache == null)
        {
            GameObjectCache = RefsAsset.Datas[GameObjectBoundIndex].TemporaryGameObjectReference;
        }
        return (GameObjectCache);
    }
}
