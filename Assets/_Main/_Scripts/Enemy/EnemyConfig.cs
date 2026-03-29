using UnityEngine;

namespace _Main._Scripts.Enemyl
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "CreateConfig/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        public int Damage;
        public int Speed;
        public int Health;
        public Sprite EnemySprite;
    }
}
