using UnityEngine;
using static HITBOX;

public class Hitbox : MonoBehaviour
{
    [Header("Hitbox")]

    #region Variables
    [Header("Variables")]
    private float frameCount = 0;
    public LAG ActiveState;
    #endregion

    #region Componentes
    [Header("Componentes")]
    public HitboxScriptable hitboxProperties;
    public PlayerMovement playerMovement;
    private BoxCollider2D Collider;
    private TransitionManager transitionManager;
    #endregion

    private void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        transitionManager = GetComponent<TransitionManager>();
        ParentOwnerAssign();
        Collider.isTrigger = true;
        ActiveState = HITBOX.LAG.Startup;
        gameObject.transform.localScale = new Vector2(hitboxProperties.hitboxData.width, hitboxProperties.hitboxData.height);
    }

    #region State Machine
    private void Update()
    {
        frameCount++;
        switch (ActiveState)
        {
            case HITBOX.LAG.Startup:
                if (frameCount >= hitboxProperties.hitboxData.startingFrames)
                {
                    ChangeActiveState(HITBOX.LAG.Active);
                }
                break;
            case HITBOX.LAG.Active:
                if (frameCount >= hitboxProperties.hitboxData.activeFrames)
                {
                    ChangeActiveState(HITBOX.LAG.End);
                }
                break;
            case HITBOX.LAG.End:
                if (frameCount >= hitboxProperties.hitboxData.endFrames)
                {
                    if (hitboxProperties.Owner == HitboxScriptable.HitboxOwner.Player)
                    {
                        playerMovement.isStunned = false;
                    }
                    Destroy(gameObject);
                }
                break;
        }
    }

    private void ChangeActiveState(HITBOX.LAG newState)
    {
        ActiveState = newState;
        switch (ActiveState)
        {
            case HITBOX.LAG.Startup:
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;

            case HITBOX.LAG.Active:
                Collider.isTrigger = true;
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;

            case HITBOX.LAG.End:
                Collider.isTrigger = false;
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;
        }
        frameCount = 0;
    }

    private void ParentOwnerAssign()
    {
        switch (hitboxProperties.Owner)
        {
            case HitboxScriptable.HitboxOwner.Player:
                transform.SetParent(GameObject.Find("Player").transform);
                break;
            case HitboxScriptable.HitboxOwner.Enemy:
                transform.SetParent(GameObject.Find("Enemy").transform);
                break;
        }
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("What");
        #region Player hits enemy.
        if (other.GetComponent<EnemyCombat>() && hitboxProperties.Owner == HitboxScriptable.HitboxOwner.Player)
        {
            GameObject.Find("Game Manager").GetComponent<TransitionManager>().SwitchToCombat();
            Debug.Log("Player Hitbox Contact with enemy.");
        }
        #endregion
        Debug.Log("please help");
        #region Enemy hits player.
        if (other.GetComponent<PlayerCombat>() && hitboxProperties.Owner == HitboxScriptable.HitboxOwner.Enemy)
        {
            Debug.Log("hi");
            other.GetComponent<PlayerCombat>().PlayerTakeDamage(hitboxProperties.hitboxData.damage);
            Debug.Log("Enemy Hitbox Contact with player.");
        }
        #endregion
    }
}
