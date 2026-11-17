using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public MANAGER GameManagement;

    private void Awake()
    {
       if (Instance == null)
       {
            Instance = this;
            DontDestroyOnLoad(gameObject);
       }
       else
       {
            Destroy(gameObject);
       }
        GameManagement.CurrentGGameState = MANAGER.GAMESTATE.BeatEmUp;
    }
    private void Start()
    {
        GameManagement.PlayerCurrentEnergy = 0;
        GameManagement.PlayerMaxEnergy = 5;
        GameManagement.PlayerCurrentEnergy = 0;
    }
}
