using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTowards : MonoBehaviour
{
  [SerializeField] float speed = 10f;

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
    float step = speed * Time.deltaTime;
    // agent.Move(Vector3.MoveTowards(transform.position, player.position, step));
    agent.SetDestination(player.position);
  }
}
