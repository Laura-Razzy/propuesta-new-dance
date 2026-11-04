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
            createHitbox(Resources.Load<HitboxScriptable>("Punch"));
            Debug.Log("Punch!");
        }
        if (Input.GetKeyDown("k"))
        {
            createHitbox(Resources.Load<HitboxScriptable>("Scriptable Objects/Hitbox/Punch"));
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

    private void createHitbox(HitboxScriptable HitboxObject)
    {
        GameObject playerHitbox = Instantiate(playerHitboxPrefab, Vector2.zero, Quaternion.identity);
        playerHitbox.gameObject.GetComponent<Hitbox>().hitboxProperties = HitboxObject;
        playerHitbox.transform.SetParent(GameObject.Find("Player").transform);
    }
}
