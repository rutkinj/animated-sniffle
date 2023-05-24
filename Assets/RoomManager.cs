using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] Door[] doors;
    [SerializeField] Health[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        doors = GetComponentsInChildren<Door>();
        enemies = GetComponentsInChildren<Health>();
    }

    // Update is called once per frame
    void Update()
    {
     if (enemies[0] == null){
        foreach(Door door in doors){
            door.OpenDoor();
        }
     }   
    }
}
