using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPickup : MonoBehaviour
{
  [SerializeField] float newReloadTime = .5f;

  [SerializeField] float rotationSpeed = 50;
  [SerializeField] float moveDistance = 3f;
  [SerializeField] float moveSpeed = 2f;

  void Update()
  {
    Animate();
  }

  private void OnTriggerEnter(Collider other)
  {
    Blammer gun = other.GetComponentInChildren<Blammer>();
    if (gun == null) return;

    gun.AttachBooster(newReloadTime);
    Destroy(gameObject);
  }

  void Animate()
  {
    transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

    Vector3 newPos = transform.position;
    newPos.y = moveDistance * (Mathf.Sin(Time.time * moveSpeed - (Mathf.PI / 2f))) + moveDistance;
    transform.position = newPos;
  }
}
