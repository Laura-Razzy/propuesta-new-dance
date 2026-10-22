using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private float CurrentBeat = 0, TotalPoints = 0;
    public string[] InputArray = new string[4];
    public float[] PointsArray = new float[4];
    private UIManager uiManager;
    private EnergyManager energyManager;
    private void Awake()
    {
        energyManager = GetComponent<EnergyManager>();
        uiManager = GetComponent<UIManager>();
    }
    void Update()
    {
        if (CurrentBeat < 1)
        {
            CurrentBeat += Time.deltaTime;
        }
        else if (CurrentBeat > 1)
        {
            CurrentBeat = 0;
        }
        if (energyManager.MoveReady)
        {
            InputTranslator();
        }
    }
    void InputTranslator()
    {
        if (Input.GetKeyDown("a"))
        {
            UpdateInputArray("left");
        }
        if (Input.GetKeyDown("s"))
        {
            UpdateInputArray("down");
        }
        if (Input.GetKeyDown("d"))
        {
            UpdateInputArray("up");
        }
        if (Input.GetKeyDown("f"))
        {
            UpdateInputArray("right");
        }
    }
    void UpdateInputArray(string pressed)
    {
        for (int i = InputArray.Length - 1; i > 0; i--)
        {
            InputArray[i] = InputArray[i - 1];
            PointsArray[i] = PointsArray[i - 1];
        }
        InputArray[0] = pressed;
        BeatChecker(CurrentBeat);
///        uiManager.MoveHistoryUpdate();
    }
    void BeatChecker(float timing)
    {
        if (timing < 0.25 || timing > 0.75)
        {
            PointsArray[0] = 100;
            uiManager.PopUp(100);
        }
        else if (timing < 0.45 || timing > 0.65)
        {
            PointsArray[0] = 200;
            uiManager.PopUp(200);
        }
        else
        {
            PointsArray[0] = 300;
            uiManager.PopUp(300);
        }
///        uiManager.PointHistoryUpdate();
        CheckMove();
    }

    void CheckMove()
    {
        bool match =
            InputArray[3] == "up" &&
            InputArray[2] == "down" &&
            InputArray[1] == "left" &&
            InputArray[0] == "right";
        if (match)
        {
            for (int i = 0; i < PointsArray.Length; i++)
            {
                TotalPoints += PointsArray[i];
                uiManager.TotalPointUpdate(TotalPoints);
            }
            for (int i = 0; i < InputArray.Length; i++)
            {
                InputArray[i] = null;
                PointsArray[i] = 0;
            }
            energyManager.CurrentEnergy = 0;
            energyManager.MoveReady = false;
        }
    }
}
