using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
  [SerializeField] Door[] doors;
  [SerializeField] Health[] enemies;
  
  void Awake()
  {
    doors = GetComponentsInChildren<Door>();
    enemies = GetComponentsInChildren<Health>();
  }

  void Update(){
    if(EnemiesDefeated()){
        OpenDoors();
    }
  }

  public bool DoorButton(){
    if(EnemiesDefeated()){
        OpenDoors();
    }
    return EnemiesDefeated();
  }

  bool EnemiesDefeated()
  {
    foreach (Health enemy in enemies)
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

}
