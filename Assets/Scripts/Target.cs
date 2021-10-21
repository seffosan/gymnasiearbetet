using UnityEngine;

public class Target : MonoBehaviour
{
  public float health = 100f;

  public void TakeDamage(float damage)
  {
    health -= damage;

    if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
  }

  private void DestroyEnemy()
  {
    Destroy(gameObject);
  }
}
