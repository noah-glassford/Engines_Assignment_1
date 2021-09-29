using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject Player;

    public List<string> TagsBulletDestroys;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag != "Player")
        {
            GameObject.Destroy(gameObject);
        }

        for (int i = 0; i < TagsBulletDestroys.Count; i++)
        {

            if (collision.gameObject.tag == TagsBulletDestroys[i])
            {
                GameObject.Destroy(collision.gameObject);
                GameObject.Destroy(gameObject);
            }
        }

    }
}
