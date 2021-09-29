using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

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

        InternalShotTimer += Time.deltaTime;

        if (InternalShotTimer >= TimeBetweenShots)
        {
            Shoot();
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
