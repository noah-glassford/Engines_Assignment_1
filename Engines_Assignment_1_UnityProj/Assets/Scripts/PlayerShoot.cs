using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
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

    private void Start()
    {

  
    }

    private void Shoot()
    {
        //Debug.Log("Shoot");
        InternalShotTimer = 0;

        GameObject SpawnedBullet = GameObject.Instantiate(BulletPrefab, FaceCube.transform.position, Quaternion.identity);

        EnemyFactory enemyFactory = new EnemyFactory();

        if (Random.Range(0f, 1f) > 0.5f)
            SpawnedBullet.GetComponent<Light>().color = enemyFactory.GetEnemy(EnemyType.Pink).GetColor();
        else
            SpawnedBullet.GetComponent<Light>().color = enemyFactory.GetEnemy(EnemyType.Red).GetColor();

        Rigidbody rb = SpawnedBullet.GetComponent<Rigidbody>();


     

        rb.AddForce(FaceCube.transform.forward * ShotSpeed);

    }
}
