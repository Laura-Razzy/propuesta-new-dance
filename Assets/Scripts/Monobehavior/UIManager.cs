using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI MANAGER")]

    #region Variables
    [Header(">VARIABLES")]
    [SerializeField] private float ElapsedTime = 0;
    [SerializeField] private float MaxTime = 1;/*
    [SerializeField] private string FirstInLine = null; 
    [SerializeField] private string SecondInLine = null; 
    [SerializeField] private string ThirdInLine = null; 
    [SerializeField] private string FourthInLine = null;*/
    #endregion

    #region Componentes
    [Header(">TEXTOS")]
    public TextMeshProUGUI MoveHistory;
    public TextMeshProUGUI PointHistory;
    public TextMeshProUGUI PointPopUp;
    public TextMeshProUGUI PointTotal;
    public TextMeshProUGUI EnergyText;
    public TextMeshProUGUI ReadyText;
    #endregion

    #region Componentes
    [Header(">COMPONENTES")]
    private InputHandler inputHandler;
    private DataManager dataManager;
    private EnergyManager energyManager;
    #endregion

    private void Start()
    {
        energyManager = GetComponent<EnergyManager>();
        MoveHistory.text = string.Empty;
        PointHistory.text = string.Empty;
        PointPopUp.text = string.Empty;
        PointTotal.text = "0";
        EnergyText.text = energyManager.intCurrentEnergy + "/" + dataManager.GameManagement.PlayerMaxEnergy;
        ReadyText.text = string.Empty;
    }

    private void Update()
    {
        ElapsedTime += Time.deltaTime;
        if (ElapsedTime >= MaxTime)
        {
            PointPopUp.text = string.Empty;
        }
        EnergyText.text = energyManager.intCurrentEnergy + "/" + energyManager.MaxEnergy;
        if (energyManager.intCurrentEnergy == energyManager.MaxEnergy)
        {
            ReadyText.text = "Move Ready";
        }
        else
        {
            ReadyText.text = string.Empty;
        }
    }

    public void PopUp(float points)
    {
        ElapsedTime = 0;
        PointPopUp.text = points.ToString();
    }

    #region History
    /*
       public void MoveHistoryUpdate()
       {
            Debug.Log("hi");
            MoveHistory.text = 
               inputHandler.InputArray[0] + "\n" +
               inputHandler.InputArray[1] + "\n" +
               inputHandler.InputArray[2] + "\n" +
               inputHandler.InputArray[3];
        public void PointHistoryUpdate()
        {
            FirstInLine = inputHandler.PointsArray[0].ToString();
            SecondInLine = inputHandler.PointsArray[1].ToString();
            ThirdInLine = inputHandler.PointsArray[2].ToString();
            FourthInLine = inputHandler.PointsArray[3].ToString();
            PointHistory.text =
                FirstInLine + "\n" +
                SecondInLine + "\n" +
                ThirdInLine + "\n" +
                FourthInLine;
        }*/
    public void TotalPointUpdate(float total)
    {
        PointTotal.text = total.ToString();
    }
    #endregion
}
