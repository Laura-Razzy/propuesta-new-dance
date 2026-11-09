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
    }
    private void Start()
    {
        GameManagement.PlayerHP = 50;
        GameManagement.PlayerCurrentEnergy = 0;
        GameManagement.PlayerMaxEnergy = 5;
    }
}
