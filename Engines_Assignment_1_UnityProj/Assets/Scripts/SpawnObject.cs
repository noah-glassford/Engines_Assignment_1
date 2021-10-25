using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    static List<GameObject> placed;


    public static void SpawnPrefab(GameObject prefab, string name)
    {
        GameObject spawned = Instantiate(prefab);
        spawned.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        spawned.name = name;

        //wall blocks are scaled to 1,3.07,1, enemies are default scale
        if (spawned.tag != "Enemy")
        {
            spawned.transform.localScale = new Vector3(1f, 3.07f, 1f);

        }
        if (placed == null)
        {
            placed = new List<GameObject>();
        }

        placed.Add(spawned);


    }

    public static void RemovePlaced(string name)
    {
        GameObject.Destroy(GameObject.Find(name));
    }

}
    
