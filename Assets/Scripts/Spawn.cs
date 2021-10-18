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
    // float x = Random.Range(minX, maxX);
    // float z = Random.Range(minZ, maxZ);

    Instantiate(spawnObj, player.position + new Vector3(0, 0 + 2, 0), Quaternion.identity);

    isSpawning = false;
    enemyAmount += 1;

  }
}
