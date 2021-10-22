using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Camera cam;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "First Person Player")
        {
            Debug.Log("Dead :)");
            //Destroy(collision.gameObject);
            //Instantiate(cam, transform.position, transform.rotation);

        }
    }
}
