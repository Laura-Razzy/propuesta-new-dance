using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private HitboxScriptable hitboxProperties;
    private float framecount = 0;
    private bool isActive = false;
    public void Awake()
    {
        gameObject.transform.localScale = new Vector2(hitboxProperties.hitboxData.width, hitboxProperties.hitboxData.height);
    }
    private void Update()
    {
        framecount =+ Time.frameCount;
        if (framecount > hitboxProperties.hitboxData.active || framecount < hitboxProperties.hitboxData.startup)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hitbox Contact with something.");
        if (other.GetComponent<EnemyCombat>() && isActive)
        {
            other.GetComponent<EnemyCombat>().TakeDamage();
            Debug.Log("Hitbox Contact with enemy.");
            Destroy(other.gameObject);
        }
    }
}
