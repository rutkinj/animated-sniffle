using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
  [SerializeField] bool openable = true;
  [SerializeField] bool keyDoor = false;
  [SerializeField] KeyType doorType;
  [SerializeField] bool removeUsedKey = false;
  [SerializeField] AudioClip openSFX;
  [SerializeField] AudioClip closeSFX;
  [SerializeField] AudioClip lockedSFX;


  Animator anim;
  RoomManager manager;
  AudioSource audioSource;

  Vector3 enterPos;


  void Awake()
  {
    anim = GetComponentInChildren<Animator>();
    manager = GetComponentInParent<RoomManager>();
    audioSource = GetComponent<AudioSource>();
    if (manager == null)
    {
      openable = false;
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Player")) return;
    enterPos = other.transform.position;

    Inventory playerInventory = other.GetComponent<Inventory>();
    if(!manager.GetIsActive() || manager.EnemiesDefeated()){
      openable = KeyCheck(playerInventory);
    }
    else openable = false;

    OpenDoor();

    // if (keyDoor && playerInventory.IsHoldingKey(doorType))
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
      audioSource.PlayOneShot(openSFX);
    }
    else
    {
      audioSource.PlayOneShot(lockedSFX);
    }
  }

  public void CloseDoor()
  {
    if (openable)
    {
      anim.SetBool("isOpen", false);
      audioSource.PlayOneShot(closeSFX);
    }
  }

  public bool KeyCheck(Inventory playerInventory){
    if (keyDoor)
    {
      return playerInventory.IsHoldingKey(doorType);
    }
    else return true;
  }
}
