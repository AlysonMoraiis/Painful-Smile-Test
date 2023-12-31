using UnityEngine;

[CreateAssetMenu(menuName = "GameData")]
public class GameData : ScriptableObject
{
    public float SessionTime;
    public float EnemySpawnTime;

    public int Points;
    public int Highscore;
    public int PlayerDamage;
}
