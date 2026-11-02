using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "New Hitbox", menuName = "Scriptables/Hitbox")]
public class HitboxScriptable : ScriptableObject
{
    public HITBOX hitboxData;
    public enum hitboxOwner
    {
        Player,
        Enemy
    }
}
