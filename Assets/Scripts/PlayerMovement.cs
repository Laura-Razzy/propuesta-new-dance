using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float HorizontalSpeed = 4, VerticalSpeed = 2;
    private float HorizontalInput, VerticalInput;
    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        VerticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        transform.Translate(HorizontalInput * HorizontalSpeed, VerticalInput * VerticalSpeed, 0);
    }
}
