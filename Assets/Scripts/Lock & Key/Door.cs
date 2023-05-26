using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
  [SerializeField] bool openable = true;
  [SerializeField] KeyType doorType;
  [SerializeField] bool removeUsedKey = true;
  [SerializeField] AudioClip openSFX;
  [SerializeField] AudioClip closeSFX;
  [SerializeField] AudioClip lockedSFX;


  Animator anim;
  RoomManager manager;
  AudioSource audio;

  Vector3 enterPos;


  void Awake()
  {
    anim = GetComponentInChildren<Animator>();
    manager = GetComponentInParent<RoomManager>();
    audio = GetComponent<AudioSource>();
    if (manager == null)
    {
      openable = false;
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Player")) return;
    enterPos = other.transform.position;
    openable = (!manager.GetIsActive() || manager.EnemiesDefeated());
    OpenDoor();

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

  private void OnTriggerExit(Collider other)
  {
    if (!other.CompareTag("Player")) return;
    CloseDoor();
    if (!manager.GetIsActive() && !manager.GetIsCleared() && Vector3.Distance(other.transform.position, enterPos) > 3.5f)
    {
      manager.RoomStart();
    }
  }

  public void OpenDoor()
  {
    if (openable)
    {
      anim.SetBool("isOpen", true);
      audio.PlayOneShot(openSFX);
    }
    else{
      audio.PlayOneShot(lockedSFX);
    }
  }

  public void CloseDoor()
  {
    if (openable)
    {
      anim.SetBool("isOpen", false);
      audio.PlayOneShot(closeSFX);
    }
  }
}
