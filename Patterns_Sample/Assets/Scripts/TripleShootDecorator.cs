
using System.Collections;
using UnityEngine;

public class TripleShootDecorator : ShootDecorator
{
    private MonoBehaviour coroutineRunner;

    private Transform spawnPoint;
    private float bulletSpeed;

    private float angleOffset = 15f;
    private float delayBetweenBullets = 0.15f;

    public TripleShootDecorator(
        IShoot shoot,
        MonoBehaviour coroutineRunner,
        Transform spawnPoint,
        float bulletSpeed
    ) : base(shoot)
    {
        this.coroutineRunner = coroutineRunner;
        this.spawnPoint = spawnPoint;
        this.bulletSpeed = bulletSpeed;
    }

    public override void Shoot()
    {
        coroutineRunner.StartCoroutine(TripleShotRoutine());
    }

    private IEnumerator TripleShotRoutine()
    {
        ShootBullet(0f);

        yield return new WaitForSeconds(delayBetweenBullets);

        ShootBullet(-angleOffset);

        yield return new WaitForSeconds(delayBetweenBullets);

        ShootBullet(angleOffset);
    }

    private void ShootBullet(float angle)
    {
        Bullet bullet = Pool.Instance.GetBullet();

        bullet.transform.position = spawnPoint.position;

        bullet.transform.rotation =
            spawnPoint.rotation *
            Quaternion.Euler(0, 0, angle);

        bullet.Rigidbody.AddForce(
            bullet.transform.up * bulletSpeed,
            ForceMode.Impulse
        );
    }
}
