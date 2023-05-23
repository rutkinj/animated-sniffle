using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
  [SerializeField] int damage = 1;
  [SerializeField] float attackCooldown = 5f;
  [SerializeField] float range = .5f;
  [SerializeField] float attackDelay = .2f;
  [SerializeField] Animator anim;
  Transform player;
  PlayerHealth playerHp;
  float currentCooldown;
  float timeInRange;


  private void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    playerHp = player.GetComponent<PlayerHealth>();
    currentCooldown = 0.0f;
  }

  void Update()
  {
    if (currentCooldown <= 0)
    {
      if (Vector3.Distance(transform.position, player.position) < range)
      {
        if (timeInRange == 0)
        {
          timeInRange = Time.time;
        }

        if (Time.time - timeInRange > attackDelay)
        {
          if (anim)
          {
            anim.SetTrigger("attack");
          }
          playerHp.TakeDamage(damage);
          currentCooldown = attackCooldown;
        }
      }
      else timeInRange = 0;
    }
    else currentCooldown -= Time.deltaTime;
  }

}
