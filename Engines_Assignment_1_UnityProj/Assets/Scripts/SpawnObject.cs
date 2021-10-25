using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnedPrefab;

    public void SpawnPrefab()
    {
        GameObject spawned = Instantiate(spawnedPrefab);
        spawned.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        

        //wall blocks are scaled to 1,3.07,1, enemies are default scale
        if (spawned.tag != "Enemy")
        {
            spawned.transform.localScale = new Vector3(1f, 3.07f, 1f);
        }
       

    }
}
