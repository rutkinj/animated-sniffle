using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    float currentSpeed;
    Vector2 velocity;
    Vector2 rawInput;

    void Awake(){
        currentSpeed = speed;
    }

    void FixedUpdate()
    {
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

    void OnRun(){
        rawInput *= new Vector2(2,2);
    }

    public void alterSpeed(float multiplier = 1){
        currentSpeed = speed * multiplier;
    }
}
