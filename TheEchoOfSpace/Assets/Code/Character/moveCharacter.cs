using UnityEditor.UIElements;
using UnityEngine;

public class moveCharacter : MonoBehaviour
{
    [Header("Характеристики игрока")]
    [Header("Скорость хотьбы")]
    public float moveSpeed;
    [Header("Скорость хотьбы")]
    public float rotationSpeed;
    [Header("Сила прыжка")]
    public float jumpForce;
    [Header("Сила двойного прыжка")]
    public float jumpDoubleForce;

    [Header("Можно ли прыгать")]
    [SerializeField] private bool isGrounded;

    [Header("Двойной прыжок")]
    [SerializeField] private bool isdoubleJump;

    Rigidbody rb;
    Animator animator;
    Vector3 position;

    [SerializeField] private string groundTag;

    [SerializeField] Transform _camera;
    Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            OnClickJump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && isdoubleJump == true)
        {
            OnDoubleJump();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        LookAroud();
    }

    private void LateUpdate()
    {
        Animation();
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag)) isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag)) isGrounded = false;
    }

    private void LookAroud()
    {
        if (position.magnitude > 0.1f && isGrounded)
        {
            Vector3 forward = _camera.forward; forward.y = 0; forward.Normalize();
            Vector3 right = _camera.right; right.y = 0; right.Normalize();

            moveDirection = forward * position.z + right * position.x;

            Quaternion rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, rotation, rotationSpeed);
        }
    }

    private void MovePlayer()
    {
        position = new Vector3(position.x = Input.GetAxisRaw("Horizontal"), 0.0f, position.z = Input.GetAxisRaw("Vertical"));
        if (position.magnitude > 0.1f && isGrounded)
        {
            rb.MovePosition(rb.position + moveDirection.normalized * moveSpeed);
        }
    }

    public void OnClickJump()
    {
        rb.AddForce(transform.forward * jumpDoubleForce, ForceMode.Impulse);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); isdoubleJump = true;
    }
    

    public void OnDoubleJump()
    {
        if (isdoubleJump == true)
        {
            rb.AddForce(transform.forward * jumpDoubleForce, ForceMode.Impulse);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); isdoubleJump = false;
        }
    }

    private void Animation()
    {
        if (position.magnitude >= 1 && isGrounded) { animator.SetBool("isMove", true); }
        else animator.SetBool("isMove", false);
    }
}
