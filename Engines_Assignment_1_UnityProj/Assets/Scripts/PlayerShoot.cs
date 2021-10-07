using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class PlayerShoot : MonoBehaviour
{


    [DllImport("Plugin")]
    private static extern float RandomFloat();




    private float DLL_Affected_ShotSpeed; //this is what gets modified by the DLL
    public float ShotSpeed = 1;
    public float TimeBetweenShots = 1;
    private float InternalShotTimer = 0f;


    [SerializeField]
    private GameObject BulletPrefab;

    [SerializeField]
    private GameObject FaceCube;

    // Update is called once per frame
    void Update()
    {

        InternalShotTimer += Time.deltaTime * DLL_Affected_ShotSpeed;

        if (InternalShotTimer >= TimeBetweenShots)
        {
            Shoot();
        }

    }

    private void Start()
    {
        DLL_Affected_ShotSpeed = RandomFloat();
        if (DLL_Affected_ShotSpeed <= 0)
        {
            DLL_Affected_ShotSpeed = 1;
        }
    }

    private void Shoot()
    {
        Debug.Log("Shoot");
        InternalShotTimer = 0;

        GameObject SpawnedBullet = GameObject.Instantiate(BulletPrefab, FaceCube.transform.position, Quaternion.identity);
        Rigidbody rb = SpawnedBullet.GetComponent<Rigidbody>();
        rb.AddForce(FaceCube.transform.right * ShotSpeed);

    }
}
