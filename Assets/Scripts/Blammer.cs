using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Blammer : MonoBehaviour
{
  [SerializeField] int damage = 1;
  [SerializeField] GameObject hitEffect;
  [SerializeField] float laserLifetime = .05f;
  Camera cam = null;
  LineRenderer line = null;

  void Awake()
  {
    cam = GetComponentInParent<Camera>();
    line = GetComponentInChildren<LineRenderer>();
  }

  void OnFire(InputValue value)
  {
    Shoot();
  }

  private void Shoot()
  {
    RaycastHit hit;
    if (Physics.Raycast(
        cam.transform.position,
        cam.transform.forward,
        out hit, 1000f))
    {
      MakeLine(transform.position, hit.point);
      SpawnHitEffect(hit);
      if (hit.transform.CompareTag("Enemy"))
      {
        hit.transform.GetComponent<Health>().TakeDamage(damage);
      }
    }

  }

  private void SpawnHitEffect(RaycastHit hit)
  {
    Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
  }

  private void MakeLine(Vector3 start, Vector3 end){
    line.enabled = true;
    line.SetPosition(0, start);
    line.SetPosition(1, end);
    line.enabled = false;
  }
}
