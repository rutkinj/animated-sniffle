using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Blammer : MonoBehaviour
{
  [SerializeField] int damage = 1;
  [SerializeField] float shotTimer = 2f;
  [SerializeField] GameObject hitEffect;
  [SerializeField] GameObject projectile;
  [SerializeField] float laserLifetime = .05f;
  [SerializeField] Transform launchPoint;
  [SerializeField] Transform guageFillOne;
  [SerializeField] Transform guageFillTwo;

  Camera cam = null;
  LineRenderer line = null;

  bool shotOneReady = true;
  float shotOneTimer = 0f;

  bool shotTwoReady = true;
  float shotTwoTimer = 0f;

  void Awake()
  {
    cam = GetComponentInParent<Camera>();
    line = GetComponentInChildren<LineRenderer>();
  }

  void Update()
  {
    ManageTimers();
  }

  void ManageTimers()
  {
    if (!shotOneReady)
    {
      shotOneTimer -= Time.deltaTime;
      guageFillOne.localPosition = new Vector3(0, shotOneTimer / -4, 0);
      guageFillOne.localScale = new Vector3(1, (shotTimer - shotOneTimer) / 2, 1);
      shotOneReady = shotOneTimer <= 0;
    }
    if (!shotTwoReady)
    {
      shotTwoTimer -= Time.deltaTime;
      guageFillTwo.localPosition = new Vector3(0, shotTwoTimer / -4, 0);
      guageFillTwo.localScale = new Vector3(1, (shotTimer - shotTwoTimer) / 2, 1);
      shotTwoReady = shotTwoTimer <= 0;
    }
  }

  void ResetTimerOne()
  {
    shotOneReady = false;
    shotOneTimer = shotTimer;
  }

  void ResetTimerTwo()
  {
    shotTwoReady = false;
    shotTwoTimer = shotTimer;
  }

  void OnFire(InputValue value)
  {
    DoShoot();
  }

  private void DoShoot()
  {
    RaycastHit hit;
    if (Physics.Raycast(
        cam.transform.position,
        cam.transform.forward,
        out hit, 1000f))
    {
      //try shot one
      if (shotOneReady)
      {
        MakeLine(transform.position, hit.point);
        SpawnHitEffect(hit);
        // SpawnProjectile(hit);
        if (hit.transform.CompareTag("Enemy"))
        {
          hit.transform.GetComponent<Health>().TakeDamage(damage);
        }
        ResetTimerOne();
      }
      else if (shotTwoReady)
      {
        MakeLine(transform.position, hit.point);
        SpawnHitEffect(hit);
        // SpawnProjectile(hit);
        if (hit.transform.CompareTag("Enemy"))
        {
          hit.transform.GetComponent<Health>().TakeDamage(damage);
        }
        ResetTimerTwo();
      }
      else
      {
        print("on cooldown!!!");
      }

    }
  }

  private void SpawnHitEffect(RaycastHit hit)
  {
    Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
  }

  private void SpawnProjectile(RaycastHit hit)
  {
    var shotta = Instantiate(projectile, launchPoint.position, Quaternion.LookRotation(hit.point, Vector3.up));
    shotta.GetComponent<Projectile>().SetTarget(hit.point);
  }

  private void MakeLine(Vector3 start, Vector3 end)
  {
    line.enabled = true;
    line.SetPosition(0, start);
    line.SetPosition(1, end);
    StartCoroutine(LaserLifetime());
  }

  IEnumerator LaserLifetime()
  {
    yield return new WaitForSeconds(laserLifetime);
    line.enabled = false;
  }
}
