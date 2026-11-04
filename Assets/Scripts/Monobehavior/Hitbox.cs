using System.Collections;
using System.Collections.Generic;
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
    #endregion

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        transform.SetParent(GameObject.Find("Player").transform);
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
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;

            case HITBOX.LAG.End:
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;
        }
        frameCount = 0;
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hitbox Contact with something.");
        if (other.GetComponent<EnemyCombat>() && ActiveState == HITBOX.LAG.Active)
        {
            other.GetComponent<EnemyCombat>().TakeDamage(hitboxProperties.hitboxData.damage);
            Debug.Log("Hitbox Contact with enemy.");
        }
    }
}
