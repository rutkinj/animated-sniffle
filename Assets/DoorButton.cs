using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    RoomManager manager;
    Door door;
    bool canOpen;

    private void Awake() {
        door = GetComponentInParent<Door>();
        manager = GetComponentInParent<RoomManager>();
    }

    public void PressButton(){
       canOpen = manager.DoorButton();
       print(canOpen);
    }
}
