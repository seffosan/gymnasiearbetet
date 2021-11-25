using UnityEngine;

public class Weapon : MonoBehaviour
{
  public Camera fpsCam;
  public static float damage = 10000f;
  public float range = 100f;
  public float fireRate = 15;
  public float bulletRandomUp = 5;
  public float bulletRandomDown = -5;
  public float impactForce = 300000f;
  public GameObject projectile;
  public GameObject gun;

  public bool isShooting;
  float x;
  /*public ParticleSystem muzzleFlash;
  public GameObject impactEffect;*/

  private float nextTimeToFire = 0;

  // Update is called once per frame
  void Update()
  {
    isShooting = false;
    UpdateShoot();
  }

  public void UpdateShoot()
  {
    x = Random.Range(bulletRandomDown, bulletRandomUp);
    if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
    {
      nextTimeToFire = Time.time + 1f / fireRate;
      shoot();
    }
  }

  // private void CheckViewable()
  // {
  //   RaycastHit hit;
  //   Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
  //   if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 5f))
  //   {
  //     float rotX = 0f;
  //     float rotY = 270f;
  //     float rotZ = 0f;
  //     ViewObject(projectile, rotX, rotY, rotZ, ray);
  //   }
  // }

  // private void ViewObject(GameObject prefab, float rotX, float rotY, float rotZ, Ray ray)
  // {
  //   Rigidbody rb = Instantiate(prefab, new Vector3(fpsCam.transform.position.x, ray.origin.y, fpsCam.transform.position.z), Quaternion.Euler(rotX, fpsCam.transform.localRotation.eulerAngles.y + rotY, rotZ)).GetComponent<Rigidbody>();
  //   rb.AddForce(transform.forward * 80f, ForceMode.Impulse);
  //   rb.AddForce(transform.up * 12f, ForceMode.Impulse);
  // }


  public void shoot()
  {
    // CheckViewable();

    /*muzzleFlash.Play();*/
    // Rigidbody rb = Instantiate(projectile, fpsCam.transform.position, Quaternion.identity).GetComponent<Rigidbody>();

    // Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.Euler(0, -90, 0)).GetComponent<Rigidbody>();
    // x = Random.Range(bulletRandomDown, bulletRandomUp);
    // rb.AddForce(transform.forward * 200f, ForceMode.Impulse);
    // rb.AddForce(transform.up * x, ForceMode.Impulse);
    // isShooting = true;

    // gun.transform.Rotate(-20.0f, 0.0f, 0.0f, Space.Self);
    // !den förra skottsaken
    RaycastHit hit;
    if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
    {


      Target target = hit.transform.GetComponent<Target>();
      if (target != null)
      {
        target.TakeDamage(damage);
      }

      if (hit.rigidbody != null)
      {

        hit.rigidbody.AddForce(-hit.normal * impactForce);
      }

      // GameObject impactGO = Instantiate(impactEffect, -hit.point, Quaternion.LookRotation(hit.normal));
      // Destroy(impactGO, 2f);

    }
  }
}