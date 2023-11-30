using UnityEngine;

[CreateAssetMenu(menuName = "PoolData")]
public class PoolData : ScriptableObject
{
    public string tag;
    public GameObject prefab;
    public int size;
}