using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private EnemyCombat enemyCombat;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Contact with something.");
        if (other.GetComponent<EnemyCombat>())
        {
            enemyCombat.TakeDamage();
            Debug.Log("Contact with enemy.");
            Destroy(other.gameObject);
        }
    }
}
