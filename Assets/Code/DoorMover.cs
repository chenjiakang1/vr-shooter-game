using UnityEngine;
using UnityEngine.XR;

public class DoorMover : MonoBehaviour
{
    public Vector3 moveOffset = new Vector3(0f, 0f, -3f); // 移动方向和距离
    public float moveDuration = 2.0f; // 移动时间（秒）
    private bool isMoving = false;
    private bool hasMoved = false;

    void Update()
    {
        if (!isMoving && !hasMoved)
        {
            if (IsVRActive())
            {
                // VR 模式：检测手柄 X 键（一般是左手控制器）
                if (XRInputDeviceButtonPressed(CommonUsages.primaryButton))
                {
                    StartCoroutine(MoveDoor());
                }
            }
            else
            {
                // PC 模式：按键盘 X 键
                if (Input.GetKeyDown(KeyCode.X))
                {
                    StartCoroutine(MoveDoor());
                }
            }
        }
    }

    System.Collections.IEnumerator MoveDoor()
    {
        isMoving = true;
        hasMoved = true;

        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + moveOffset;

        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
        isMoving = false;
    }

    // 判断当前是否处于 VR 模式
    bool IsVRActive()
    {
        return XRSettings.isDeviceActive;
    }

    // 检测指定按钮是否按下（XR 控制器）
    bool XRInputDeviceButtonPressed(InputFeatureUsage<bool> button)
    {
        InputDevice leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (leftHand.isValid && leftHand.TryGetFeatureValue(button, out bool pressed))
        {
            return pressed;
        }
        return false;
    }
}
