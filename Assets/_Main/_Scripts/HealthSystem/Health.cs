using System;

namespace _Main._Scripts.HealthSystem
{
    public class Health
    {
        public int VHealth { get; private set; }
        public Action OnHealthChanged;

        public Health(int maxHealth)
        {
            if(maxHealth <= 0) VHealth = 100;
            VHealth = maxHealth;
        }
        public void SetHealth(int vHealth)
        {
            VHealth = vHealth;
            OnHealthChanged?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            VHealth -= damage;
            OnHealthChanged?.Invoke();
        }
    }
}
