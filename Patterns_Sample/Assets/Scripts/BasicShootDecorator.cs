using UnityEngine;

public class BasicShootDecorator : ShootDecorator
{
    private Transform spawnPoint;
    private float bulletSpeed;

    public BasicShootDecorator(
        IShoot shoot,
        Transform spawnPoint,
        float bulletSpeed
    ) : base(shoot)
    {
        this.spawnPoint = spawnPoint;
        this.bulletSpeed = bulletSpeed;
    }

    public override void Shoot()
    {
        Bullet bullet = Pool.Instance.GetBullet();

        bullet.transform.position = spawnPoint.position;
        bullet.transform.rotation = spawnPoint.rotation;

        bullet.Rigidbody.AddForce(
            spawnPoint.up * bulletSpeed,
            ForceMode.Impulse
        );
    }
}