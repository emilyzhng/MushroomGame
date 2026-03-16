using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "MushroomScriptable", menuName = "Scriptable Objects/MushroomScriptable")]
public class MushroomScriptable : ScriptableObject
{
    public string mushroomName;
    public bool isPoisonous;
    public Sprite icon;
}
