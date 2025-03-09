using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    public float sensive;
    public float maxAngle;

    public float rotationX = 0.0f;
    public float rotationY = 0.0f;

    public void onFreeRotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX * sensive);
        transform.Rotate(Vector3.up * mouseY * sensive);

        rotationX -= mouseY * sensive;
        rotationX = Mathf.Clamp(rotationX, -maxAngle, maxAngle);
        rotationY += mouseX * sensive;
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
    }
}

