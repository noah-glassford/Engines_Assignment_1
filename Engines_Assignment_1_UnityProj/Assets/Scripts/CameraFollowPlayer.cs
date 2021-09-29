using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    //Simple script to follow player without parenting since rotation messes up the camera

    [SerializeField]
    private GameObject player;

    private void Update()
    {
        Vector3 playerPos = player.transform.position;
        playerPos.y = 10;
        transform.position = playerPos;
        
    }

}
