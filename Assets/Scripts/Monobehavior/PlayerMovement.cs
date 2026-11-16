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

    #region Componentes
    private SpriteRenderer spriteRenderer;
    #endregion

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!isStunned)
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            if (HorizontalInput < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (HorizontalInput > 0)
            {
                spriteRenderer.flipX = false;
            } 

            VerticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime;
            transform.Translate(HorizontalInput * HorizontalSpeed, VerticalInput * VerticalSpeed, 0);
        }
    }
}
