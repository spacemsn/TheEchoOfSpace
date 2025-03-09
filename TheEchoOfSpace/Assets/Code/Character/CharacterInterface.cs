using UnityEngine;

public class CharacterInterface : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.visible = true; Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false; Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
