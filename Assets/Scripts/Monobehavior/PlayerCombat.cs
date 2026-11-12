using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("PLAYER COMBAT")]

    #region Componentes
    [Header(">COMPONENTES")]
    [SerializeField] private GameObject playerHitboxPrefab;
    private PlayerMovement playerMovement;
    private DataManager dataManager;
    private UIManager uiManager;
    #endregion

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        dataManager = GetComponent<DataManager>();
        uiManager = GameObject.Find("Game Manager").GetComponent<UIManager>();
        dataManager = GameObject.Find("Game Manager").GetComponent<DataManager>();
        uiManager = GameObject.Find("Game Manager").GetComponent<UIManager>();
        dataManager.GameManagement.PlayerHP = 50;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (!playerMovement.isStunned)
        {
            if (Input.GetKeyDown("j"))
            {
                CreateHitbox(Resources.Load<HitboxScriptable>("Hitbox/Punch"), transform.position.x + 1, transform.position.y + 0.25f);
                Debug.Log("Punch!");
            }
            if (Input.GetKeyDown("k"))
            {
                CreateHitbox(Resources.Load<HitboxScriptable>("Hitbox/Kick"), transform.position.x + 1, transform.position.y - 1);
                Debug.Log("Kick!");
            }
        }
    }

    private void CreateHitbox(HitboxScriptable HitboxObject, float HorizontalSpawn, float VerticalSpawn)
    {
        playerMovement.isStunned = true;
        GameObject playerHitbox = Instantiate(playerHitboxPrefab, new Vector2(HorizontalSpawn, VerticalSpawn), Quaternion.identity);
        playerHitbox.transform.SetParent(GameObject.Find("Player").transform);
        playerHitbox.gameObject.GetComponent<Hitbox>().hitboxProperties = HitboxObject;
    }

    public void PlayerTakeDamage(float DamageTaken)
    {
        dataManager.GameManagement.PlayerHP -= DamageTaken;
        Debug.Log(dataManager.GameManagement.PlayerHP);
        if (dataManager.GameManagement.PlayerHP <= 0)
        {
            Debug.Log("You Lose!");
            uiManager.GameOver();
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("What");
        if (other.GetComponent<Item>())
        {
            Debug.Log("Item Get!");
            Destroy(other.gameObject);
        }
    }
}