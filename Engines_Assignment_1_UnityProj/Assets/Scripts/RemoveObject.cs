using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RemoveObject : MonoBehaviour
{
    public bool isSetToRemove = false;

    public TextMeshProUGUI buttonText;


    private void Update()
    {

        if (isSetToRemove) //only run the delete code if in delete mode
        {
            RaycastHit theObject;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out theObject))
                {
                    if (theObject.transform.gameObject.tag != "Player" && theObject.transform.gameObject.tag != "Dont Destroy") //can't delete the player
                        GameObject.Destroy(theObject.transform.gameObject);
                }
            }
        }
    }

    public void ToggleRemove()
    {
        if (isSetToRemove)
        {
            buttonText.text = "Delete Mode";
        }
        else
        {
            buttonText.text = "Regular Mode";
        }

        isSetToRemove = !isSetToRemove;
    }
}
