using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float crouchTransition = 4.0f;

    [Header("Sensitivity")]
    [SerializeField] private float sensitivityX = 1.0f;
    [SerializeField] private float sensitivityY = 2.0f;

    private const float limitY = 90.0f;

    private CharacterController controller;
    [SerializeField] private GameObject target;

    private Vector3 direction = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 orientation = Vector3.zero;

    private Vector3 gravity = Physics.gravity;

    private float crouchAmount = 0.0f;

    // Start is called before the first frame update
    private void Start()
    {
        controller = this.GetComponent<CharacterController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        MouseMovement();
        CharacterMovement();
    }

    private void MouseMovement()
    {
        orientation.x -= Input.GetAxisRaw("Mouse Y") * sensitivityY;
        orientation.x = Mathf.Clamp(orientation.x, -limitY, limitY);

        orientation.y += Input.GetAxisRaw("Mouse X") * sensitivityX;

        if (Mathf.Abs(orientation.y) >= 360.0f)
            orientation.y = 0.0f;

        target.transform.eulerAngles = orientation;
    }

    private void CharacterMovement()
    {
        bool isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = 0.0f;
        }

        bool isCrouching = Input.GetButton("Crouch") && isGrounded;

        if (isCrouching)
        {
            crouchAmount = Mathf.Clamp01(crouchAmount + Time.deltaTime * crouchTransition);
            target.transform.localPosition = Vector3.Lerp(Vector3.up, Vector3.zero, crouchAmount);
        }
        else if (crouchAmount > 0.0f)
        {
            crouchAmount = Mathf.Clamp01(crouchAmount - Time.deltaTime * crouchTransition);
            target.transform.localPosition = Vector3.Lerp(Vector3.up, Vector3.zero, crouchAmount);
        }

        direction = (Input.GetAxisRaw("Horizontal") * target.transform.right) + (Input.GetAxisRaw("Vertical") * target.transform.forward);
        direction = Vector3.ProjectOnPlane(direction, Vector3.up).normalized;

        controller.Move(direction * moveSpeed * (isCrouching ? 0.5f : (Input.GetButton("Sprint") ? 2.0f : 1.0f)) * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity.y);
        }

        velocity.y += gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
