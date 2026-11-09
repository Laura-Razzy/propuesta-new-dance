using System;

[Serializable]
public struct HITBOX
{
    public float damage;
    public float width;
    public float height;
    public float startingFrames;
    public float activeFrames;
    public float endFrames;
    public enum LAG
        {
            Startup,
            Active,
            End
        }
}

public struct DIALOGUE
{
    public string characterName;
    public string phrase;
}

public struct MANAGER
{
    public float PlayerHP;
    public float PlayerCurrentEnergy;
    public float PlayerMaxEnergy;
    public float TotalPoints;
    public string SavedMove;
    public enum GAMESTATE
    {
        Menu,
        BeatEmUp,
        SmallFight,
        BigFight
    }
    public GAMESTATE CurrentGGameState;
}
