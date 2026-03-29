using _Main._Scripts.Player.Guns;
using UnityEngine;

public class Pistol : MasterGun
{
    [Header("Components")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _firePoint;

    [Header("Gun Values")]
    [SerializeField] private int _bulletSpeed;
    [SerializeField] private int _damage;

    public override void Attack()
    {
        GameObject bullet = Instantiate(_bullet, _firePoint);
        bullet.transform.SetParent(null);

        var rb = bullet.GetComponent<Rigidbody2D>();
        var bulletScript = bullet.GetComponent<Bullet>();

        bulletScript.Init(_damage);

        rb.AddForce(bullet.transform.right * _bulletSpeed, ForceMode2D.Impulse);
    }
}
