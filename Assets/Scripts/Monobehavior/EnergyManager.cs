using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public float CurrentEnergy = 0, MaxEnergy = 5;
    public bool CombatStart = true, MoveReady = false;
    private void Start()
    {
        if (CombatStart)
        {
            CurrentEnergy = 0;
            CombatStart = false;
            MoveReady = false;

        }
    }
    void Update()
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
