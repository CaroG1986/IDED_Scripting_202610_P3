using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 5f;

    [SerializeField]
    private float tripleShotDuration = 5f;

    private IShoot currentShoot;

    private void Start()
    {
        
        currentShoot = new BasicShootDecorator(
            null,
            Player.Instance.BulletSpawnPoint,
            bulletSpeed
        );
    }

   

    public void ActivateTripleShot()
    {
        currentShoot = new TripleShootDecorator(
            currentShoot,
            this,
            Player.Instance.BulletSpawnPoint,
            bulletSpeed
        );

        StartCoroutine(TripleShotTimer());
    }

    private IEnumerator TripleShotTimer()
    {
        yield return new WaitForSeconds(tripleShotDuration);

        currentShoot = new BasicShootDecorator(
            null,
            Player.Instance.BulletSpawnPoint,
            bulletSpeed
        );
    }
}