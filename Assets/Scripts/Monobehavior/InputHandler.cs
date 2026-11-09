using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("INPUT HANDLER")]

    #region Variables
    [Header("Variables")]
    [SerializeField] private float CurrentBeat = 0;
    [SerializeField] private float TotalPoints = 0;
    public enum INPUT
    {
        empty,
        left, 
        down,  
        up, 
        right 
    }
    public INPUT InputDirection;
    public INPUT[] InputArray = new INPUT[4];
    public float[] PointsArray = new float[4];
    #endregion

    #region Componentes
    [Header("Componentes")]
    private UIManager uiManager;
    private EnergyManager energyManager;
    private TransitionManager transitionManager;
    #endregion

    private void Awake()
    {
        energyManager = GetComponent<EnergyManager>();
        uiManager = GetComponent<UIManager>();
        transitionManager = GetComponent<TransitionManager>();
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
            transform.position = new Vector3(-6.22f, -1.52f, 0);
        }
        if (energyManager.MoveReady)
        {
            InputTranslator();
        }
    }

    #region Inputs
    void InputTranslator()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(-6.22f, -1.52f, 0);
            InputDirection = INPUT.left;
            transform.Translate(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = new Vector3(-6.22f, -1.52f, 0);
            InputDirection = INPUT.down;
            transform.Translate(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            transform.position = new Vector3(-6.22f, -1.52f, 0);
            InputDirection = INPUT.up;
            transform.Translate(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.position = new Vector3(-6.22f, -1.52f, 0);
            InputDirection = INPUT.right;
            transform.Translate(1, 0, 0);
        }
        UpdateInputArray(InputDirection);
        InputDirection = INPUT.empty;
    }

    void UpdateInputArray(INPUT pressed)
    {
        if (pressed != INPUT.empty)
        {
            for (int i = InputArray.Length - 1; i > 0; i--)
            {
                InputArray[i] = InputArray[i - 1];
                PointsArray[i] = PointsArray[i - 1];
            }
            InputArray[0] = pressed;
            BeatChecker(CurrentBeat);
        }
        /*
        uiManager.MoveHistoryUpdate();
        */
    }
    #endregion

    #region Move/Rhythm Managers
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
        /*
        uiManager.PointHistoryUpdate();
        */
        CheckMove();
    }

    void CheckMove()
    {
        bool match =
            InputArray[3] == INPUT.up &&
            InputArray[2] == INPUT.down &&
            InputArray[1] == INPUT.left &&
            InputArray[0] == INPUT.right;
        if (match)
        {
            for (int i = 0; i < PointsArray.Length; i++)
            {
                TotalPoints += PointsArray[i];
                uiManager.TotalPointUpdate(TotalPoints);
                transitionManager.SwitchToBeatEmUp();
            }
            for (int i = 0; i < InputArray.Length; i++)
            {
                InputArray[i] = INPUT.empty;
                PointsArray[i] = 0;
            }
            energyManager.CurrentEnergy = 0;
            energyManager.MoveReady = false;
        }
    }
    #endregion
}
