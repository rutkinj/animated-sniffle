using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] int maxHitPoints = 10;
  [SerializeField] float healthRecharge = 5;
  [SerializeField] Slider healthDisplay;
  [SerializeField] Image healthDisplayFill;
  [SerializeField] AudioSource sfx;
  int hitpoints = 0;
  float currentHealthRecharge = 0;
  bool isDead = false;

  private void Awake()
  {
    hitpoints = maxHitPoints;
    UpdateDisplay();
  }

  private void Update(){
    HealthRecharge();

  }

  public void TakeDamage(int damage)
  {
    if (isDead) return;
    hitpoints -= damage;
    currentHealthRecharge = healthRecharge;
    sfx.Play();
    UpdateDisplay();

    if (hitpoints <= 0)
    {
      StartCoroutine(Die());
    }
  }

  public void HealthRecharge(){
    if(hitpoints == maxHitPoints) return;
    currentHealthRecharge -= Time.deltaTime;
    if(currentHealthRecharge <= 0){
      hitpoints += 1;
      UpdateDisplay();
      currentHealthRecharge = healthRecharge;
    }
  }

  private IEnumerator Die()
  {
    // anim.SetTrigger("die");
    healthDisplayFill.enabled = false;
    isDead = true;
    yield return new WaitForSeconds(5);
    FindObjectOfType<SceneLoader>().DoRestart();
  }

  public bool IsDead()
  {
    return isDead;
  }

  private void UpdateDisplay()
  {
    print(hitpoints / maxHitPoints);
    healthDisplay.SetValueWithoutNotify((float)hitpoints / (float)maxHitPoints);
  }
}
