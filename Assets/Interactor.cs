using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
  Camera cam;

  void Awake()
  {
    cam = GetComponentInParent<Camera>();
  }

  void OnInteract(InputValue value)
  {
    RaycastHit hit;
    if(Physics.SphereCast(cam.transform.position, 1f, cam.transform.forward, out hit, 10f)){
        print("we've got something");
    }
    else print("missed");
  }
}
