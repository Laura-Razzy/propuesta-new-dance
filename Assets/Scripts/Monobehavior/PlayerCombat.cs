using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("PLAYER COMBAT")]

    #region Stats
    [Header("Stats")]
    [SerializeField] private float PlayerHP = 50;
    #endregion

    #region Componentes
    [Header("Componentes")]
    [SerializeField] private GameObject playerHitboxPrefab;
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            CreateHitbox(Resources.Load<HitboxScriptable>("Hitbox/Punch"));
            Debug.Log("Punch!");
        }
        if (Input.GetKeyDown("k"))
        {
            CreateHitbox(Resources.Load<HitboxScriptable>("Hitbox/Kick"));
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

    private void CreateHitbox(HitboxScriptable HitboxObject)
    {
        GameObject playerHitbox = Instantiate(playerHitboxPrefab, transform);
        playerHitbox.gameObject.GetComponent<Hitbox>().hitboxProperties = HitboxObject;
    }

    public void PlayerTakeDamage(float DamageTaken)
    {
        PlayerHP -= DamageTaken;
        if (PlayerHP <= 0)
        {
            Debug.Log("You Lose!");
            Destroy(gameObject);
        }
    }
}
