using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private float HP = 20;
    public void TakeDamage()
    {
        Debug.Log("Enemy takes damage!");
    }
}
