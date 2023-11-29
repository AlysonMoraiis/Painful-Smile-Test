using UnityEngine;

[CreateAssetMenu(menuName = "GameData")]
public class GameData : ScriptableObject
{
    public float SessionTime;
    public float EnemySpawnTime;

    public int Points;
    public int PlayerDamage;
    
    
    #region Enemy

    public int ChaserDamage;
    public int ShooterDamage;

    #endregion
}
