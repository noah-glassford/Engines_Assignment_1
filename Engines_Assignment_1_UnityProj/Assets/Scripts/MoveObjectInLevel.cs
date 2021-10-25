using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectInLevel : MonoBehaviour
{
  
    public GameObject internalObject;
    public RaycastHit theObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out theObject))
            {
                if (theObject.transform.gameObject.tag != "Dont Destroy")
                {
                    internalObject = theObject.transform.gameObject;
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out theObject);
            Vector3 point;
            point = theObject.point;
            point.y = theObject.transform.position.y;

            internalObject.transform.position = point;

        }
    }
}
