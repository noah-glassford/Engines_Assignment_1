using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;


    // Update is called once per frame
    void Update()
    {
        //Vector used to calculate movement
        Vector3 InputMovementVec = new Vector3();

        //These 2 sections are a bunch of if statements which is kinda messey, but Input.GetAxis() doesn't differentiate between arrow keys and wasd.
        #region WASD Movement
        //I'm not using the Input.Getaxis function here since I want Arrow keys and WASD to be seperate
        if (Input.GetKey(KeyCode.W))
        {
            InputMovementVec.z += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            InputMovementVec.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            InputMovementVec.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            InputMovementVec.x += 1;
        }
        #endregion

        #region Arrow Key Rotation
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion


        InputMovementVec *= Time.deltaTime;

        transform.Translate(InputMovementVec * MovementSpeed, Space.World);



    }
}
