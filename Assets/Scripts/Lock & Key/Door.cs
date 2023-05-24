using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
  [SerializeField] bool openable = true;
  [SerializeField] KeyType doorType;
  [SerializeField] bool removeUsedKey = true;

  Animator anim;

  void Awake()
  {
    anim = GetComponentInChildren<Animator>();
  }

  void OnTriggerEnter(Collider other)
  {
    Inventory playerInventory = other.GetComponent<Inventory>();

    if (playerInventory == null) { return; }
    if (anim == null) { return; }

    if (playerInventory.IsHoldingKey(doorType))
    {
      OpenDoor();
      if (removeUsedKey)
      {
        playerInventory.RemoveKey(doorType);
      }
    }
  }

  public void OpenDoor()
  {
    if (openable)
    {
      anim.SetBool("isOpen", true);
    }
  }
}
