using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
  [SerializeField] bool openable = true;
  [SerializeField] KeyType doorType;
  [SerializeField] bool removeUsedKey = true;

  Animator anim;
  RoomManager manager;

  void Awake()
  {
    anim = GetComponentInChildren<Animator>();
    manager = GetComponentInParent<RoomManager>();
  }

  void OnTriggerEnter(Collider other)
  {
    if(!other.CompareTag("Player")) return;
    if(manager.GetIsCleared() || !manager.GetIsActive()){
      OpenDoor();
    }


    // manager.CheckStatus()

    // Inventory playerInventory = other.GetComponent<Inventory>();

    // if (playerInventory == null) { return; }
    // if (anim == null) { return; }

    // if (playerInventory.IsHoldingKey(doorType))
    // {
    //   OpenDoor();
    //   if (removeUsedKey)
    //   {
    //     playerInventory.RemoveKey(doorType);
    //   }
    // }
  }

  private void OnTriggerExit(Collider other) {
    CloseDoor();
    if(!manager.GetIsActive()){
      manager.RoomStart();
    }
  }

  public void OpenDoor()
  {
    if (openable)
    {
      anim.SetBool("isOpen", true);
    }
  }

  public void CloseDoor()
  {
    if (openable)
    {
      anim.SetBool("isOpen", false);
    }
  }
}
