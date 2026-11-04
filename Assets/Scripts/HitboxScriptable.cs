using UnityEngine;

[CreateAssetMenu(fileName = "New Hitbox", menuName = "Scriptables/Hitbox")]
public class HitboxScriptable : ScriptableObject
{
    public enum hitboxOwner
    {
        Player,
        Enemy
    }
    public hitboxOwner Owner;
    public HITBOX hitboxData;
}
