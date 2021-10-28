using UnityEngine;

public class Weapon : MonoBehaviour
{
  public static float damage = 30f;
  public float range = 100f;
  public float fireRate = 15;
  public float bulletRandomUp = 10;
  public float bulletRandomDown = -10;
  public float impactForce = 300000f;
  public GameObject projectile;
  float x;
  public Camera fpsCam;
  /*public ParticleSystem muzzleFlash;
  public GameObject impactEffect;*/

  private float nextTimeToFire = 0;

  // Update is called once per frame
  void Update()
  {
    UpdateShoot();
  }

  public void UpdateShoot()
  {

    if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
    {
      nextTimeToFire = Time.time + 1f / fireRate;
      x = Random.Range(bulletRandomDown, bulletRandomUp);
      shoot();
    }
  }

  private void CheckViewable()
  {
    RaycastHit hit;
    Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 5f))
    {
      float rotX = 0f;
      float rotY = 270f;
      float rotZ = 0f;
      ViewObject(projectile, rotX, rotY, rotZ, ray);
    }
  }

  private void ViewObject(GameObject prefab, float rotX, float rotY, float rotZ, Ray ray)
  {
    Rigidbody rb = Instantiate(prefab, new Vector3(fpsCam.transform.position.x, ray.origin.y, fpsCam.transform.position.z), Quaternion.Euler(rotX, fpsCam.transform.localRotation.eulerAngles.y + rotY, rotZ)).GetComponent<Rigidbody>();
    rb.AddForce(transform.forward * 80f, ForceMode.Impulse);
    rb.AddForce(transform.up * x, ForceMode.Impulse);
  }


  public void shoot()
  {
    CheckViewable();

    /*muzzleFlash.Play();*/

    // Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
    // rb.AddForce(transform.forward * 80f, ForceMode.Impulse);
    // rb.AddForce(transform.up * x, ForceMode.Impulse);

    // !den förra skottsaken
    // RaycastHit hit;
    // if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
    // {


    // Target target = hit.transform.GetComponent<Target>();
    // if (target != null)
    // {
    // target.TakeDamage(damage);
    // }

    // if (hit.rigidbody != null)
    // {

    // hit.rigidbody.AddForce(-hit.normal * impactForce);
    // }

    /*GameObject impactGO = Instantiate(impactEffect, -hit.point, Quaternion.LookRotation(hit.normal));
    Destroy(impactGO, 2f);*/


  }
}