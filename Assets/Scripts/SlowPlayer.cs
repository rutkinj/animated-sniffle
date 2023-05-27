using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{
  [SerializeField, Range(0, 1)] float speedAlter = 0.5f;
  FirstPersonMovement player;
  // Start is called before the first frame update
  void Start()
  {
    player = FindObjectOfType<FirstPersonMovement>();
  }

  // Update is called once per frame

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      player.alterSpeed(speedAlter);
    }
  }

  private void OnTriggerExit(Collider other) {
    if (other.CompareTag("Player"))
    {
      player.alterSpeed();
    }
  }

  public void DoSlow(float alter = 1){
    player.alterSpeed(alter);
  }
}
