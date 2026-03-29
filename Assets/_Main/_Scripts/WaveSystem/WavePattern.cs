using _Main._Scripts.Enemyl;
using UnityEngine;

namespace _Main._Scripts.WaveSystem
{
    [CreateAssetMenu(fileName =  "WavePattern", menuName = "CreatePattern/WavePattern")]
    public class WavePattern : ScriptableObject
    {
        public int NumberOfEnemies;
        public EnemyConfig[] Enemies;
    
    }
}