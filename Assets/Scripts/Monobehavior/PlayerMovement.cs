using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("PLAYER MOVEMENT")]

    #region Variables
    [Header("Variables")]
    [SerializeField] private float HorizontalSpeed = 4; 
    [SerializeField] private float VerticalSpeed = 2;
    private float HorizontalInput; 
    private float VerticalInput;
    public bool isStunned = false;
    #endregion

    void Update()
    {
        if (!isStunned)
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            VerticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime;
            transform.Translate(HorizontalInput * HorizontalSpeed, VerticalInput * VerticalSpeed, 0);
        }
    }
}
