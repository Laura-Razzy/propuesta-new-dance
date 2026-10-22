using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] private float ElapsedTime = 0, MaxTime = 1;
    [SerializeField] private string FirstInLine = null, SecondInLine = null, ThirdInLine = null, FourthInLine = null;
    public TextMeshProUGUI MoveHistory, PointHistory, PointPopUp, PointTotal;
    private InputHandler inputHandler;
    private void Start()
    {
        MoveHistory.text = string.Empty;
        PointHistory.text = string.Empty;
        PointPopUp.text = string.Empty;
        PointTotal.text = "0";
    }
    private void Update()
    {
        ElapsedTime += Time.deltaTime;
        if (ElapsedTime >= MaxTime)
        {
            PointPopUp.text = string.Empty;
        }
    }
    public void PopUp(float points)
    {
        ElapsedTime = 0;
        PointPopUp.text = points.ToString();
    }
///    public void MoveHistoryUpdate()
///    {
///        MoveHistory.text = 
///            inputHandler.InputArray[0] + "\n" +
///            inputHandler.InputArray[1] + "\n" +
///            inputHandler.InputArray[2] + "\n" +
///            inputHandler.InputArray[3];
///    }
///    public void PointHistoryUpdate()
///    {
///        FirstInLine = inputHandler.PointsArray[0].ToString();
///        SecondInLine = inputHandler.PointsArray[1].ToString();
///        ThirdInLine = inputHandler.PointsArray[2].ToString();
///        FourthInLine = inputHandler.PointsArray[3].ToString();
///        PointHistory.text =
///            FirstInLine + "\n" +
///            SecondInLine + "\n" +
///            ThirdInLine + "\n" +
///            FourthInLine;
///    }
    public void TotalPointUpdate(float total)
    {
        PointTotal.text = total.ToString();
    }
}
