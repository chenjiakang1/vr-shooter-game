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

        // 限制刚体旋转，避免因碰撞而旋转角色
        rb.freezeRotation = true;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // 计算基于摄像机方向的移动
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 direction = forward * inputVector.y + right * inputVector.x;
        direction.Normalize();

        // 使用刚体 velocity 控制移动，避免墙角挤偏
        Vector3 velocity = direction * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        // 动画控制（只使用 Speed）
        if (animator != null)
        {
            animator.SetFloat("Speed", direction.magnitude);
        }
    }
}
