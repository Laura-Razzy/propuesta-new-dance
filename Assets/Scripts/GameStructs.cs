using System;
using Unity.Collections;
using Unity.VisualScripting;

[Serializable]
public struct HITBOX
{
    public string name;
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
    public LAG ActiveState;
}

public struct DIALOGUE
{
    public string characterName;
    public string phrase;
}
