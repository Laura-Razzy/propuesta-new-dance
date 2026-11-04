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
            //Debug.Log("Enemy Attack!");
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
}
