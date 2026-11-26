using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("INPUT HANDLER")]

    #region Variables
    [Header("Variables")]
    [SerializeField] private float CurrentBeat = 0;
    [SerializeField] private float TotalPoints = 0;
    private float previousHorizontal;
    private float previousVertical;
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
    
    [SerializeField] GameObject gameManager;
    private DataManager dataManager;
    private BossUIManager bossUIManager;
    private EnergyManager energyManager;
    private TransitionManager transitionManager;
    private DanceAudioManager danceAudioManager;
    #endregion

    private void Awake()
    {
        energyManager = GetComponent<EnergyManager>();
        bossUIManager = GameObject.Find("Canvas").GetComponent<BossUIManager>();
        dataManager = gameManager.GetComponent<DataManager>();
        transitionManager = gameManager.GetComponent<TransitionManager>();
        danceAudioManager = GetComponent<DanceAudioManager>();
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
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetAxisRaw("DPadHorizontal") < 0 && previousHorizontal >= 0))
        {
            transform.position = new Vector3(-6.22f, -1.52f, 0);
            InputDirection = INPUT.left;
            transform.Translate(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.F) || (Input.GetAxisRaw("DPadVertical") < 0 && previousVertical >= 0))
        {
            transform.position = new Vector3(-6.22f, -1.52f, 0);
            InputDirection = INPUT.down;
            transform.Translate(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.J) || (Input.GetAxisRaw("DPadVertical") > 0 && previousVertical <= 0))
        {
            transform.position = new Vector3(-6.22f, -1.52f, 0);
            InputDirection = INPUT.up;
            transform.Translate(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.K) || (Input.GetAxisRaw("DPadHorizontal") > 0 && previousHorizontal <= 0))
        {
            transform.position = new Vector3(-6.22f, -1.52f, 0);
            InputDirection = INPUT.right;
            transform.Translate(1, 0, 0);
        }
        UpdateInputArray(InputDirection);
        InputDirection = INPUT.empty;
        previousHorizontal = Input.GetAxisRaw("DPadHorizontal");
        previousVertical = Input.GetAxisRaw("DPadVertical");
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
            bossUIManager.PopUp(100);
            danceAudioManager.notehitOneShot();
        }
        else if (timing < 0.45 || timing > 0.65)
        {
            PointsArray[0] = 200;
            bossUIManager.PopUp(200);
            danceAudioManager.notehitOneShot();
        }
        else
        {
            PointsArray[0] = 300;
            bossUIManager.PopUp(300);
            danceAudioManager.wellDoneOneShot();
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
                bossUIManager.TotalPointUpdate(TotalPoints);
                transitionManager.SwitchToBeatEmUp();
                dataManager.GameManagement.CurrentGGameState = MANAGER.GAMESTATE.BeatEmUp;
            }
            for (int i = 0; i < InputArray.Length; i++)
            {
                InputArray[i] = INPUT.empty;
                PointsArray[i] = 0;
            }
            dataManager.GameManagement.PlayerCurrentEnergy = 0;
            energyManager.MoveReady = false;
            danceAudioManager.victoryOneShot();
        }
    }
    #endregion
}
