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
        ICommand command = new PlaceObjectCommand(prefabTemp, ( "PlacedObject" + prefabTemp.GetInstanceID()));
        CommandInvoker.AddCommand(command);
    }

}
