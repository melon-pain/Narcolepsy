using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5.0f;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private const float limitY = 90.0f;

    private CharacterController controller;

    private Vector3 direction = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 orientation = Vector3.zero;
    private Vector3 gravity = Physics.gravity;

    private bool isMoving = false;

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
        Movement();
    }

    private void Movement()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
            return;

        bool isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = 0.0f;
        }

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0,  Input.GetAxis("Vertical"));
        direction = Camera.main.transform.TransformDirection(direction);
        direction = Vector3.ProjectOnPlane(direction, Vector3.up).normalized;

        float sprintSpeed = (Input.GetButton("Sprint") ? 2.0f : 1.0f);

        controller.Move(direction * moveSpeed * sprintSpeed * Time.deltaTime);

        isMoving = direction.sqrMagnitude > float.Epsilon;
        animator.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            Vector3 forward = Vector3.ProjectOnPlane(direction, Vector3.up);
            if (forward.sqrMagnitude > 0.1f)
                this.transform.forward = forward;
        }

        velocity.y += gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void CursorVisible()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResetPosition()
    {
        Destroy(controller);
        StartCoroutine(A());
        CursorVisible();
    }

    private IEnumerator A()
    {
        yield return null;
        this.transform.localPosition = Vector3.down * 0.4f;
        this.transform.localEulerAngles = Vector3.up * 90.0f;
    }
}
