using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private float HP = 20;
    void Start()
    {
        Debug.Log("Enemy has spawned.");
    }
    public void TakeDamage()
    {
        Debug.Log("Enemy takes damage!");
    }
}
