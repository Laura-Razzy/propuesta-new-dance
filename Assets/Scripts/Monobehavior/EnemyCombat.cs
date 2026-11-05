using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header("ENEMY COMBAT")]

    #region Variables
    [Header("VARIABLES")]
    [SerializeField] private float RandomTime;
    [SerializeField] private float ElapsedTime;
    #endregion

    #region Stats
    [Header("STATS")]
    [SerializeField] private float EnemyHP = 20;
    #endregion

    #region
    [Header("COMPONENTES")]
    [SerializeField] private GameObject enemyHitboxPrefab;
    #endregion

    private void Awake()
    {
        ElapsedTime = 0;
        RandomTime = Random.Range(1, 10);
    }

    private void Update()
    {
        ElapsedTime += Time.deltaTime;
        if (ElapsedTime >= RandomTime)
        {
            CreateHitbox(Resources.Load<HitboxScriptable>("Hitbox/EnemyPunch"), transform.position.x - 1, transform.position.y + 0.25f);
            RandomTime = Random.Range(1, 10);
            ElapsedTime = 0;
        }
    }

    // Takes damage if collides with player hitbox, if it has 0 or less HP, dies.
    public void TakeDamage(float DamageTaken) 
    {
        EnemyHP -= DamageTaken;
        if (EnemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void CreateHitbox(HitboxScriptable HitboxObject, float HorizontalSpawn, float VerticalSpawn)
    {
        GameObject playerHitbox = Instantiate(enemyHitboxPrefab, new Vector2(HorizontalSpawn, VerticalSpawn), Quaternion.identity);
        playerHitbox.transform.SetParent(GameObject.Find("Enemy").transform);
        playerHitbox.gameObject.GetComponent<Hitbox>().hitboxProperties = HitboxObject;
    }

    /* GOD IS DEAD
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hitbox Contact with something.");
        if (other.GetComponent<PlayerCombat>())  
        {
            other.GetComponent<PlayerCombat>().PlayerTakeDamage(20);
            Debug.Log("Hitbox Contact with player.");
        }
    }
    */
}
