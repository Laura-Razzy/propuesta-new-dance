using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("PLAYER COMBAT")]

    #region Stats
    [Header("Stats")]
    [SerializeField] private float PlayerHP;
    #endregion

    #region Componentes
    [Header("Componentes")]
    [SerializeField] private GameObject playerHitboxPrefab;
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            Debug.Log("Punch!");
        }
        if (Input.GetKeyDown("k"))
        {
            Debug.Log("Kick!");
        }
    }

    // Takes damage if collides with enemy hitbox, if it has 0 or less HP, dies.
    public void TakeDamage(float DamageTaken)
    {
        PlayerHP -= DamageTaken;
        if (PlayerHP <= 0)
        {
            Debug.Log("You Lose!");
            Destroy(gameObject);
        }
    }
}
