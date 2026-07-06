using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float turnSpeed = 50f;

    public float acceleration = 15f;
    public float deceleration = 10f;
    public float brakeStrength = 25f;

    private Rigidbody rb;
    private Vector2 moveInput;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float targetSpeed = moveInput.y * maxSpeed;

        bool isBraking = Mathf.Sign(currentSpeed) != 0 &&
                          Mathf.Sign(moveInput.y) != 0 &&
                          Mathf.Sign(moveInput.y) != Mathf.Sign(currentSpeed);

        float rate;
        if (moveInput.y == 0f)
            rate = deceleration;
        else if (isBraking)
            rate = brakeStrength;
        else
            rate = acceleration;

        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, rate * Time.fixedDeltaTime);

        Vector3 forwardMovement = transform.forward * currentSpeed;
        rb.linearVelocity = new Vector3(forwardMovement.x, rb.linearVelocity.y, forwardMovement.z);

        float turn = moveInput.x * turnSpeed * Time.fixedDeltaTime * Mathf.Sign(currentSpeed);
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}