using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EnemyCount : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI EnemiesLeftText;

    private void Update()
    {
        int EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        EnemiesLeftText.text = "Enemies Left: " + EnemyCount.ToString();

        if (EnemyCount <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

}
