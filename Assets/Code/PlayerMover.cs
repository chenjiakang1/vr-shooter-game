using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [Header("移动速度")]
    public float moveSpeed = 2f;

    [Header("参考摄像机朝向")]
    public Transform cameraTransform;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 direction = (forward.normalized * vertical + right.normalized * horizontal).normalized;
        Vector3 movement = direction * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(forward);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * 10f));
        }
    }
}
