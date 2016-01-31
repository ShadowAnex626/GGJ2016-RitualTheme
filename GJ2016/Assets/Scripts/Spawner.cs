using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Transform[] enemy;
    public float spawn;
    public Transform[] spawnPoint;

    void Start()
    {
        InvokeRepeating("Spawn", 1f, 10f);       
    }

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoint.Length);
        int enemyIndex = Random.Range(0, enemy.Length);
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(enemy[0], spawnPoint[i].position, spawnPoint[i].rotation);
        }
    }
}

