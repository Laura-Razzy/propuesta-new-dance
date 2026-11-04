using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [Header("Hitbox")]

    #region Variables
    [Header("Variables")]
    private float framecount = 0;
    #endregion

    #region Componentes
    [Header("Componentes")]
    public HitboxScriptable hitboxProperties;
    #endregion

    private void Awake()
    {
        Debug.Log(this.enabled);
        gameObject.transform.localScale = new Vector2(hitboxProperties.hitboxData.width, hitboxProperties.hitboxData.height);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void Start()
    {
        hitboxProperties.hitboxData.ActiveState = HITBOX.LAG.Startup;
    }

    #region State Machine
    private void Update()
    {
        framecount += Time.frameCount;
        switch (hitboxProperties.hitboxData.ActiveState)
        {
            case HITBOX.LAG.Startup:
                if (framecount >= hitboxProperties.hitboxData.startingFrames)
                {
                    ChangeActiveState(HITBOX.LAG.Active);
                }
                break;
            case HITBOX.LAG.Active:
                if (framecount >= hitboxProperties.hitboxData.activeFrames)
                {
                    ChangeActiveState(HITBOX.LAG.End);
                }
                break;
            case HITBOX.LAG.End:
                if (framecount >= hitboxProperties.hitboxData.endFrames)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }

    private void ChangeActiveState(HITBOX.LAG newState)
    {
        hitboxProperties.hitboxData.ActiveState = newState;
        switch (hitboxProperties.hitboxData.ActiveState)
        {
            case HITBOX.LAG.Startup:
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;

            case HITBOX.LAG.Active:
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;

            case HITBOX.LAG.End:
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;
        }
        framecount = 0;
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hitbox Contact with something.");
        if (other.GetComponent<EnemyCombat>() && hitboxProperties.hitboxData.ActiveState == HITBOX.LAG.Active)
        {
            other.GetComponent<EnemyCombat>().TakeDamage(hitboxProperties.hitboxData.damage);
            Debug.Log("Hitbox Contact with enemy.");
        }
    }
}
