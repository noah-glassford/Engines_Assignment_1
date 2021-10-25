using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectCommand : ICommand
{
    GameObject prefab;
    string GameObjectName;
    Transform playerTransform;
    

    public PlaceObjectCommand(GameObject prefab, string name, Transform placeLoc)
    {
        this.prefab = prefab;
        this.GameObjectName = name;
        this.playerTransform = placeLoc;
    }

    public void Execute()
    {
        SpawnObject.SpawnPrefab(prefab, GameObjectName, playerTransform);
    }

    public void Undo()
    {
        SpawnObject.RemovePlaced(GameObjectName);
    }
}
