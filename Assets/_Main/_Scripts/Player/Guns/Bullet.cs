using _Main._Scripts.Enemyl;
using _Main._Scripts.HealthSystem;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage;
    [SerializeField] private float _bulletLifeTime;
    public void Init(int damage)
    {
        _damage = damage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<HealthModule>(out HealthModule enemyHealth))
        {
            enemyHealth.Health.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
    private void Update()
    {
        if (_bulletLifeTime < 0)
        {
            Destroy(gameObject);
        }
        else _bulletLifeTime -= Time.deltaTime;
    }
}
