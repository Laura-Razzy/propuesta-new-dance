using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    [Header("ENERGY MANAGER")]

    #region Variables
    [Header("VARIABLES")]
    public float CurrentEnergy;
    public float MaxEnergy;
    public bool CombatStart = true;
    public bool MoveReady = false;
    #endregion

    private void Start()
    {
        MaxEnergy = 5;
        if (CombatStart)
        {
            CurrentEnergy = 0;
            CombatStart = false;
            MoveReady = false;
        }
    }

    private void Update()
    {
        if (CurrentEnergy < MaxEnergy)
        {
            CurrentEnergy += Time.deltaTime;
        }
        else
        {
            Debug.Log("Move ready!");
            MoveReady = true;
        }
    }
}
