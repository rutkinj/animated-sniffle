using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] int maxHitPoints = 5;
  [SerializeField] TextMeshProUGUI healthDisplay;
  //   [SerializeField] Animator anim;
  [SerializeField] AudioSource sfx;
  int hitpoints = 0;
  bool isDead = false;

  private void Awake()
  {
    hitpoints = maxHitPoints;
    UpdateDisplay();
  }

  public void TakeDamage(int damage)
  {
    hitpoints -= damage;
    sfx.Play();
    UpdateDisplay();

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

  public bool IsDead()
  {
    return isDead;
  }

  private void UpdateDisplay()
  {
    healthDisplay.text = hitpoints.ToString();
  }
}
