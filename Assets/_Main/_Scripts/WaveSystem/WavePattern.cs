using UnityEngine;

[CreateAssetMenu(fileName =  "WavePattern", menuName = "CreatePattern/WavePattern")]
public class WavePattern : ScriptableObject
{
    public int NumberOfEnemies;
    public GameObject[] Enemies;
    
}