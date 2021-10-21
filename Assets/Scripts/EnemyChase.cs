using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
  public NavMeshAgent agent;

  public Transform player;

  public LayerMask whatIsGround, whatIsPlayer;

  //Patroling
  public Vector3 walkPoint;
  bool walkPointSet;
  public float walkPointRange;

  //Attacking
  public float timeBetweenAttacks;
  bool alreadyAttacked;
  public GameObject projectile;

  //States
  public float attackRange;
  public bool playerInAttackRange;

  private void Awake()
  {
    player = GameObject.Find("First Person Player").transform;
    agent = GetComponent<NavMeshAgent>();
  }

  private void Update()
  {
    playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

    if (!playerInAttackRange) ChasePlayer();
    if (playerInAttackRange) AttackPlayer();
  }


  private void ChasePlayer()
  {
    if (player != null)
    {
      agent.SetDestination(player.position);
    }
  }

  private void AttackPlayer()
  {
    if (player != null)
    {
      agent.SetDestination(transform.position);

      transform.LookAt(player);

      if (!alreadyAttacked)
      {
        Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 80f, ForceMode.Impulse);
        rb.AddForce(transform.up * 8f, ForceMode.Impulse);
        Debug.Log("attack");

        alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
      }
    }
  }

  private void ResetAttack()
  {
    alreadyAttacked = false;
  }


  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, attackRange);
  }
}
