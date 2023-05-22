using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
  [SerializeField] int damage = 1;
  [SerializeField] float cooldown = 5f;
  [SerializeField] float range = .5f;
  Transform player;
  PlayerHealth playerHp;
  float currentCooldown;


  private void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    playerHp = player.GetComponent<PlayerHealth>();
  }

  void Update()
  {
    if (currentCooldown <= 0)
    {
      if (Vector3.Distance(transform.position, player.position) < range)
      {
        playerHp.TakeDamage(damage);
        currentCooldown = cooldown;
      }
    }
    else currentCooldown -= Time.deltaTime;
  }

}
