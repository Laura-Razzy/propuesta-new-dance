using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private float CurrentBeat = 0, TotalPoints = 0;
    [SerializeField] private string[] InputArray = new string[4];
    [SerializeField] private float[] PointsArray = new float[4];

    void Update()
    {
        if (CurrentBeat < 1)
        {
            CurrentBeat += Time.deltaTime;
        }
        else
        {
            CurrentBeat = 0;
        }
        if (GetComponent<EnergyManager>().MoveReady)
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
    }
    void BeatChecker(float timing)
    {

        if (timing < 0.25 || timing > 0.75)
        {
            PointsArray[0] = 100;
        }
        else if (timing < 0.45 || timing > 0.65)
        {
            PointsArray[0] = 200;
        }
        else
        {
            PointsArray[0] = 300;
        }
    }
    void NiceMove()
    {
        
    }
}
