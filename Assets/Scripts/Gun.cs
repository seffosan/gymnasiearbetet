using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
  public float damage;
  public float impactForce, fireRate;
  public Camera aimCam;
  public ParticleSystem flash;
  public GameObject effect;
  public GameObject effect2;

  float fireTime = 0f;

  void Update()
  {
    // !Kontroll
    if (Input.GetButton("Fire1") && Time.time >= fireTime)
    {
      fireTime = Time.time + 1f / fireRate;
      FindObjectOfType<AudioManager>().Play("pew");
      Shoot();
    }

    if (Input.GetKeyDown(KeyCode.Space))
    {
      FindObjectOfType<AudioManager>().Play("WJump");
      Debug.Log("JUMP"); 
    }

    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
      FindObjectOfType<AudioManager>().Play("WRun");
    }

    if (Input.GetKeyDown(KeyCode.W))
    {
      FindObjectOfType<AudioManager>().Play("gun");
    }

    if (Input.GetKeyDown(KeyCode.D))
    {
      FindObjectOfType<AudioManager>().Play("gun");
    }

    if (Input.GetKeyDown(KeyCode.S))
    {
      FindObjectOfType<AudioManager>().Play("WHit2");
    }
    
    if (Input.GetKeyDown(KeyCode.A))
    {
      FindObjectOfType<AudioManager>().Play("WHit2");
    }
  }

  void Shoot()
  {
    // !Skottet
    RaycastHit hit;
    if (Physics.Raycast(aimCam.transform.position, aimCam.transform.forward, out hit))
    {

      Target target = hit.transform.GetComponent<Target>();

      // !Skadar Target
      if (target != null)
      {
        target.TakeDamage(damage);
        FindObjectOfType<AudioManager>().Play("Whit");
        FindObjectOfType<AudioManager>().Play("WHit2");
        GameObject effektGO2 = Instantiate(effect2, hit.point, Quaternion.identity);
        Destroy(effektGO2, 1f);
        Score.scoreValue += 20;
      }
      else
      {
        GameObject effektGO = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(effektGO, 1f);
      }

      // !Force
      if (hit.rigidbody != null)
      {
        hit.rigidbody.AddForce(-hit.normal * impactForce);
      }
    }

    else
    {
      flash.Play();
    }

  }
}