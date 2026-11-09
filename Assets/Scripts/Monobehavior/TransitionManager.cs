using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public void SwitchToCombat()
    {
        SceneManager.LoadScene("BigFight");
    }

    public void SwitchToBeatEmUp()
    {
        SceneManager.LoadScene("BeatEmUp");
    }
}
