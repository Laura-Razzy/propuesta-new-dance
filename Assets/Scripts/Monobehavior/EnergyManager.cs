using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    [Header("ENERGY MANAGER")]

    #region Variables
    [Header(">VARIABLES")]
    public float CurrentEnergy;
    public float MaxEnergy;
    public int intCurrentEnergy;
    public bool CombatStart = true;
    public bool MoveReady = false;
    #endregion

    #region Componentes
    [Header(">COMPONENTES")]
    private DataManager dataManager;
    #endregion

    private void Start()
    {
        dataManager = GameObject.Find("Game Manager").GetComponent<DataManager>();
        intCurrentEnergy = (int)dataManager.GameManagement.PlayerCurrentEnergy;
        if (CombatStart)
        {
            dataManager.GameManagement.PlayerCurrentEnergy = 0;
            CombatStart = false;
            MoveReady = false;
        }
    }

    private void Update()
    {
        if (dataManager.GameManagement.PlayerCurrentEnergy < dataManager.GameManagement.PlayerMaxEnergy)
        {
            dataManager.GameManagement.PlayerCurrentEnergy += Time.deltaTime;
            intCurrentEnergy = (int)dataManager.GameManagement.PlayerCurrentEnergy;
        }
        else
        {
            MoveReady = true;
        }
    }
}
