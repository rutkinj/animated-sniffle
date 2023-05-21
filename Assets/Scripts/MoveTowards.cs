using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTowards : MonoBehaviour
{
  [SerializeField] float speed = 3f;
  [SerializeField] float moveDelay = 1f;
  float step;
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

  void Move2d()
  {
    print("started move 2d");
    // while (!Mathf.Approximately(player.position.x, transform.position.x) &&
    // !Mathf.Approximately(player.position.z, transform.position.z))
    // {
    step = speed * Time.deltaTime;
    float xDist = player.position.x - transform.position.x;
    float zDist = player.position.z - transform.position.z;

    bool moveX = Mathf.Abs(xDist) > Mathf.Abs(zDist);

    if (moveX)
    {
      print("moving x");
      //move x
      if (xDist > 0)
      {
        print("moving right");
        transform.Translate(Vector3.right * step, Space.World);
      }
      else
      {
        print("moving left");

        transform.Translate(Vector3.left * step, Space.World);
      }
    }
    else
    {
      //move z
      print("moving z");
      if (zDist < 0)
      {
        print("moving back");

        transform.Translate(Vector3.back * step, Space.World);
      }
      else
      {
        print("moving fwd");

        transform.Translate(Vector3.forward * step, Space.World);
      }
    }
  }


}
