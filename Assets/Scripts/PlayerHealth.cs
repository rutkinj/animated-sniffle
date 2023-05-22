using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] int hitpoints = 5;
//   [SerializeField] Animator anim;
    bool isDead = false;

  public void TakeDamage(int damage)
  {
    hitpoints -= damage;

    if (hitpoints <= 0)
    {
      Die();
    }
  }

  private void Die()
  {
    // anim.SetTrigger("die");
    isDead = true;
  }

  public bool IsDead(){
    return isDead;
  }
}
