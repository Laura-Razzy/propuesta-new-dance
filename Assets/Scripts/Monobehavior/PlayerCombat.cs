using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject hitboxPrefab;
    private void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            Debug.Log("Punch!");
        }
        if (Input.GetKeyDown("k"))
        {
            Debug.Log("Kick!");
        }
    }
}
