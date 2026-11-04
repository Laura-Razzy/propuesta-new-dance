using UnityEngine;

[CreateAssetMenu(fileName = "New Hitbox", menuName = "Scriptables/Hitbox")]
public class HitboxScriptable : ScriptableObject
{
    public string HitboxName;
    public enum HitboxOwner
    {
        Player,
        Enemy
    }
    public HitboxOwner Owner;
    public HITBOX hitboxData;
}
