using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
  public GameObject spawnObj;
  public Transform player;

  public float minX, maxX, minZ, maxZ, minSpawnTime, maxSpawnTime, maxEnemy, enemyAmount;
  private bool isSpawning;
  private float timer, timeSinceStart, difficultyMultiplier;

  // !Is spawn ska vara False från 1-frame
  void Awake()
  {
    player = GameObject.Find("First Person Player").transform;
    isSpawning = false;
    timeSinceStart = 0;
  }

  void Update()
  {

    timeSinceStart = Time.deltaTime / 5;
    // !Ger en liten random delay efter varje Spawn
    if (!isSpawning && maxEnemy >= enemyAmount)
    {
      timer = Random.Range(minSpawnTime, maxSpawnTime);
      Invoke("SpawnObject1", timer);

      isSpawning = true;
    }
  }
  void SpawnObject1()
  {
    // !Spawnar fienden i Random plats

    GameObject instance = Instantiate(spawnObj, player.position + new Vector3(0, 0 + 2, 0), Quaternion.identity);
    instance.transform.Rotate(Vector3.up, Random.Range(0f, 360f));

    isSpawning = false;
    enemyAmount += 1;

    // List<Transform> near = new List<Transform>();
    // foreach (Transform spawnPoint in transform.childCount)
    // {
    //   if (Vector3.Distance(player.transform.position, spawnPoint.position) < 10)
    //   {
    //     near.Add(spawnPoint);
    //   }

    //   if (near.Count > 0)
    //   {
    //     int index = Random.Range(0, spawnPoint.Count);
    //     Transform spawnAt = spawnPoints[index];
    //     if (spawnAt != null)
    //     {
    //       GameObject instance = Instantiate(objectToSpawn, spawnAt.position, Quaternion.identity);
    //       instance.transform.Rotate(Vector3.up, Random.Range(0f, 360f));
    //     }
    //   }
    // }

  }
}
