using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonPlace : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;


    public void WhenButtonPressed()
    {

        GameObject prefabTemp = prefab;

        //pass enemy into enemy factory
        if (prefabTemp.tag == "enemy")
        {
            EnemyFactory enemyFactory = new EnemyFactory();

            if (Random.Range(0f, 1f) > 0.5f)
            prefabTemp.GetComponent<Renderer>().material.color = enemyFactory.GetEnemy(EnemyType.Pink).GetColor();
            else
            prefabTemp.GetComponent<Renderer>().material.color = enemyFactory.GetEnemy(EnemyType.Red).GetColor();

        }


        ICommand command = new PlaceObjectCommand(prefabTemp, ( "PlacedObject" + prefabTemp.GetInstanceID()), GameObject.FindGameObjectWithTag("Player").transform);
        CommandInvoker.AddCommand(command);
    }

}
