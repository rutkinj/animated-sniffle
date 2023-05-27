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
  [SerializeField] Transform booster;
  [Header("SFX")]
  [SerializeField] AudioClip fireSFX;
  [SerializeField] AudioClip cooldownSFX;

  Camera cam = null;
  LineRenderer line = null;
  AudioSource SFX;

  bool shotOneReady = true;
  float shotOneTimer = 0f;

  bool shotTwoReady = true;
  float shotTwoTimer = 0f;

  PlayerHealth health;
  FirstPersonMovement mover;

  void Awake()
  {
    cam = GetComponentInParent<Camera>();
    line = GetComponentInChildren<LineRenderer>();
    SFX = GetComponent<AudioSource>();
    health = FindObjectOfType<PlayerHealth>();
    mover = FindObjectOfType<FirstPersonMovement>();
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
      guageFillOne.localPosition = new Vector3(0, shotOneTimer / (-2*shotTimer), 0);
      guageFillOne.localScale = new Vector3(1, (shotTimer - shotOneTimer) / shotTimer, 1);
      shotOneReady = shotOneTimer <= 0;
    }
    if (!shotTwoReady)
    {
      shotTwoTimer -= Time.deltaTime;
      guageFillTwo.localPosition = new Vector3(0, shotTwoTimer / (-2 * shotTimer), 0);
      guageFillTwo.localScale = new Vector3(1, (shotTimer - shotTwoTimer) / shotTimer, 1);
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
    if(health.IsDead() || mover.isFrozen()) return;
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
        SFX.PlayOneShot(fireSFX);
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
        SFX.PlayOneShot(fireSFX);
        // SpawnProjectile(hit);
        if (hit.transform.CompareTag("Enemy"))
        {
          hit.transform.GetComponent<Health>().TakeDamage(damage);
        }
        ResetTimerTwo();
      }
      else
      {
        SFX.PlayOneShot(cooldownSFX);
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

  public void AttachBooster(float newShotTimer){
    booster.gameObject.SetActive(true);
    shotTimer = newShotTimer;
  }
}
