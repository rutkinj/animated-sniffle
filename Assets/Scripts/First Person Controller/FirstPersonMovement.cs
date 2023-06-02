using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
  [SerializeField] float speed = 5;
  float currentSpeed;
  Vector2 velocity;
  Vector2 rawInput;
  bool frozen;
  PlayerHealth health;

  void Awake()
  {
    currentSpeed = speed;
    health = GetComponent<PlayerHealth>();
  }

  void FixedUpdate()
  {
    if (frozen || health.IsDead()) return;
    MoveCharacter();
  }

  void MoveCharacter()
  {
    velocity.x = rawInput.x * currentSpeed * Time.deltaTime;
    velocity.y = rawInput.y * currentSpeed * Time.deltaTime;
    transform.Translate(velocity.x, 0, velocity.y);
  }

  void OnMove(InputValue value)
  {
    rawInput = value.Get<Vector2>();
  }

  void OnRun(InputValue value)
  {
    if(value.isPressed){
        currentSpeed = speed * 2;
    }
    if(!value.isPressed){
        currentSpeed = speed;
    }

  }

  public void alterSpeed(float multiplier = 1)
  {
    currentSpeed = speed * multiplier;
  }

  public void Freeze()
  {
    frozen = true;
  }

  public bool isFrozen()
  {
    return frozen;
  }
}
