using UnityEngine;

[CreateAssetMenu(fileName = "Room_var_", menuName = "ScriptableObjects/RoomScriptableObject", order = 1)]
public class Room : ScriptableObject
{
    public GameObject Prefab;

    public Vector2 roomSize;

}
