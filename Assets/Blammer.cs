using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Blammer : MonoBehaviour
{
  [SerializeField] int damage = 1;
  Camera cam = null;

  void Awake()
  {
    cam = GetComponentInParent<Camera>();
  }

  void OnFire(InputValue value)
  {
    Shoot();
  }

  private void Shoot()
  {
    RaycastHit hit;
    Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 1000f);
    if (hit.transform.CompareTag("Enemy"))
    {
      hit.transform.GetComponent<Health>().TakeDamage(damage);
    }
  }
}
