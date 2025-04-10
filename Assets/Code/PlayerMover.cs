using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 2f;
    public Transform cameraTransform;
    public Animator animator;

    private Rigidbody rb;
    private Vector2 inputVector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // 计算摄像机前向和右向
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // 移动方向
        Vector3 direction = forward * inputVector.y + right * inputVector.x;
        direction.Normalize();

        // 移动位置
        Vector3 movement = direction * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // 控制朝向
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * 10f));
        }

        // 控制动画
        if (animator != null)
        {
            animator.SetFloat("Speed", direction.magnitude);
        }
    }
}
