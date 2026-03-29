using _Main._Scripts.HealthSystem;
using UnityEngine;
using NavMeshPlus;
using UnityEngine.AI;
using _Main._Scripts.Player;

namespace _Main._Scripts.Enemyl
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        public EnemyConfig Config { get; private set; }

        private NavMeshAgent _agent;

        private int _damage;
        private GameObject _target;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateUpAxis = false;
            _agent.updateRotation = false;

            _target = FindFirstObjectByType<PlayerController>().gameObject;
        }

        public void Init(EnemyConfig config)
        {
            Config = config;
            
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            HealthModule healthModule = GetComponent<HealthModule>();
            
            spriteRenderer.sprite = config.EnemySprite;
        
            _damage = config.Damage;
            _agent.speed = config.Speed;
        }
        private void FixedUpdate()
        {
            if (_target != null)
                _agent.SetDestination(_target.transform.position);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent<PlayerController>(out PlayerController controller))
            {
                foreach (var module in controller.Modules) 
                {
                    if (module is HealthModule)
                    {
                        var healthModule = (HealthModule)module;
                        healthModule.Health.TakeDamage(_damage);
                    }
                    
                }

                
            }
        }

    }
}
