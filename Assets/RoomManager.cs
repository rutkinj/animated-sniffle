using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
  [SerializeField] Door[] doors;
  [SerializeField] MoveTowards[] enemies;

  bool isCleared = false;
  bool isActive = false;

  void Awake()
  {
    doors = GetComponentsInChildren<Door>();
    enemies = GetComponentsInChildren<MoveTowards>();
    RoomSetup();
  }

  void Update()
  {
    // if (EnemiesDefeated())
    // {
    //   OpenDoors();
    // }
  }



  public bool DoorButton()
  {
    if (EnemiesDefeated())
    {
      OpenDoors();
    }
    return EnemiesDefeated();
  }

  public bool EnemiesDefeated()
  {
    foreach (MoveTowards enemy in enemies)
    {
      if (enemy != null)
      {
        return false;
      }
    }
    isActive = false;
    isCleared = true;
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
      enemy.GetComponent<Animator>().speed = 0;
    }
  }

  public void RoomStart()
  {
    if(isCleared)return;
    isActive = true;
    foreach (MoveTowards enemy in enemies)
    {
      enemy.canMove = true;
      enemy.GetComponent<Animator>().speed = 1;
    }
  }

  public bool GetIsCleared()
  {
    return isCleared;
  }

  public bool GetIsActive()
  {
    return isActive;
  }
}
