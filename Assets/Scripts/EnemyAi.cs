using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
  public NavMeshAgent agent;
  public Transform player;

  void Awake()
  {
    player = GameObject.Find("First Person Player").transform;
    agent = GetComponent<NavMeshAgent>();
  }

  void Update()
  {
    agent.SetDestination(player.position);
  }

}