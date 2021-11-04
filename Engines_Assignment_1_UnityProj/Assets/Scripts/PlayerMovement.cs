using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The look at mouse code was taken from:
//https://github.com/BarthaSzabolcs/Tutorial-IsometricAiming/blob/main/Assets/Scripts/Simple%20-%20CopyThis/IsometricAiming.cs
//https://www.youtube.com/watch?v=AOVCKEJE6A8



public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;

    [SerializeField] private LayerMask groundMask;

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


        InputMovementVec *= Time.deltaTime;

        transform.Translate(InputMovementVec * MovementSpeed, Space.World);

        Aim();

    }


    private void Aim()
    {



        var (success, position) = GetMousePosition();
        if (success)
        {
            Debug.Log("Test");

            // Calculate the direction
            var direction = position - transform.position;

            // You might want to delete this line.
            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
        }
    }


    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }

    }



}
