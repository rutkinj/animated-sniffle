using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
  [SerializeField] Door[] doors;
  [SerializeField] MoveTowards[] enemies;

  void Awake()
  {
    doors = GetComponentsInChildren<Door>();
    enemies = GetComponentsInChildren<MoveTowards>();
    RoomSetup();
  }

  void Update()
  {
    if (EnemiesDefeated())
    {
      OpenDoors();
    }
  }

  public bool DoorButton()
  {
    if (EnemiesDefeated())
    {
      OpenDoors();
    }
    return EnemiesDefeated();
  }

  bool EnemiesDefeated()
  {
    foreach (MoveTowards enemy in enemies)
    {
      if (enemy != null)
      {
        return false;
      }
    }
    return true;
  }

  void OpenDoors()
  {
    foreach (Door door in doors)
    {
      door.OpenDoor();
    }
  }

  void RoomSetup()
  {
    foreach (MoveTowards enemy in enemies)
    {
      enemy.canMove = false;
    }
  }

  void RoomStart()
  {
    foreach (MoveTowards enemy in enemies)
    {
      enemy.canMove = true;
    }
  }
}
