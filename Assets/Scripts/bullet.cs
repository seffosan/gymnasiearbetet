using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name == "First Person Player")
    {
      Debug.Log("-30hp");

      Destroy(collision.gameObject);
    }
  }
}
