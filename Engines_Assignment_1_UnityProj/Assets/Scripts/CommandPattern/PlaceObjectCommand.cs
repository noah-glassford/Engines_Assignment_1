using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectCommand : ICommand
{
    GameObject prefab;
    string GameObjectName;
    

    public PlaceObjectCommand(GameObject prefab, string name)
    {
        this.prefab = prefab;
        this.GameObjectName = name;
    }

    public void Execute()
    {
        SpawnObject.SpawnPrefab(prefab, GameObjectName);
    }

    public void Undo()
    {
        SpawnObject.RemovePlaced(GameObjectName);
    }
}
