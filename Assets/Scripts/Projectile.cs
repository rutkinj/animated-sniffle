using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  [SerializeField] float speed = 100f;
  [SerializeField] int damage = 1;
  public Vector3 origin;
  public Vector3 target;
  public Vector3 dir;
  private bool hasTarget = false;

  void LateUpdate()
  {
    if (Vector3.Distance(transform.position, origin) > Vector3.Distance(target, origin))
    {
      DoDestroy();
    }
    if (hasTarget)
    {
      DoProjectile();
    }
  }

  public void SetTarget(Vector3 target)
  {
    this.target = target;
    dir = (target - transform.position).normalized;
    hasTarget = true;
  }

  private void DoProjectile()
  {

    // transform.Translate(Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime));
    transform.position += dir * speed * Time.deltaTime;
  }

  private void DoDestroy()
  {
    hasTarget = false;
    Destroy(gameObject, 2f);
  }

}
