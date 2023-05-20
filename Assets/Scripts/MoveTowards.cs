using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTowards : MonoBehaviour
{
  Transform player = null;
  NavMeshAgent agent = null;

  void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    agent = GetComponent<NavMeshAgent>();
  }

  // Update is called once per frame
  void Update()
  {
    Move();
  }

  void Move()
  {
    agent.SetDestination(player.position);
  }
}
