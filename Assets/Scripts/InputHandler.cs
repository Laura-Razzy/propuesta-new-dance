using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private float CurrentBeat = 0;
    [SerializeField] private string[] InputArray = new string[4];
    [SerializeField] private float[] PointsArray = new float[4];

    void Update()
    {
        if (CurrentBeat < 1)
        {
            CurrentBeat += Time.deltaTime;
            BeatCheker(CurrentBeat);
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

    void UpdateInputArray(string pressed)
    {
        for (int i = 0; i < InputArray.Length; i++)
        {
            if (InputArray[i] == null)
            {
                InputArray[i] = pressed;
                break;
            }
            else if (InputArray[3] != null)
            {
                InputArray[3 - i] = InputArray[2 - i];
                InputArray[0] = pressed;
            }
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
    void BeatCheker(float timing)
    {

    }
}
