using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
  [SerializeField] float jumpStrength = 2;
  GroundCheck groundCheck;
  PlayerHealth health;
  Rigidbody rb;
  bool isJumping = false;

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
    health = GetComponent<PlayerHealth>();

    SetupGroundCheck();
  }

  void LateUpdate()
  {
    if (isJumping)
    {
      isJumping = false;
      rb.AddForce(Vector3.up * 100 * jumpStrength);
    }
  }

  void OnJump(InputValue value)
  {
    if (groundCheck.isGrounded && !health.IsDead())
    {
      isJumping = value.isPressed;
    }
  }

  void SetupGroundCheck()
  {
    groundCheck = GetComponentInChildren<GroundCheck>();
    if (!groundCheck)
    {
      groundCheck = GroundCheck.Create(transform);
    }
  }
}
