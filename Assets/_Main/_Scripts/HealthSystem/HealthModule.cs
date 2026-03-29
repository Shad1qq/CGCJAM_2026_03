using UnityEngine;
using _Main._Scripts.Enemyl;
using _Main._Scripts.WaveSystem;
using Zenject;

namespace _Main._Scripts.HealthSystem
{
    public class HealthModule : MonoBehaviour, IModule
    {
        [Header("Health Value")]
        [SerializeField]private int _maxHealth;

        public Health Health;
        public void Disable()
        {
            Health.OnHealthChanged -= TryDie;
            this.enabled = false;

        }
        public void Enable()
        {
            Health.OnHealthChanged += TryDie;
            this.enabled = true;
        }

        private void Start()
        {
            if (TryGetComponent<Enemy>(out Enemy enemy)) _maxHealth = enemy.Config.Health;

            Health = new Health(_maxHealth);
            Health.OnHealthChanged += TryDie;
        }
        private void TryDie()
        {
            Debug.Log("Damaged" + Health.VHealth);
            if(Health.VHealth <= 0)
                Destroy(gameObject);        
        }
        private void OnDestroy()
        {
            WaveManager.EnemyDestroyedInvoke();
        }

    }
}