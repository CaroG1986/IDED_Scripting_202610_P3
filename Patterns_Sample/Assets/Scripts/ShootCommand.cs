using UnityEngine;

public class ShootCommand : MonoBehaviour, ICommand
{
    [Header("Bullet")]
    [SerializeField]
    private float bulletSpeed = 3f;

    [Header("Decorator")]
    [SerializeField]
    private float tripleShotDuration = 5f;

    private IShoot currentShoot;

    private Transform BulletSpawnPoint =>
        Player.Instance.BulletSpawnPoint;

    private void Start()
    {
        
        currentShoot = new BasicShootDecorator(
            null,
            BulletSpawnPoint,
            bulletSpeed
        );
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Execute();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ActivateTripleShot();
        }
    }

    public void Execute()
    {

        currentShoot.Shoot();
    }

    public void ActivateTripleShot()
    {
       
        currentShoot = new TripleShootDecorator(
            currentShoot,
            this,
            BulletSpawnPoint,
            bulletSpeed
        );

        
        Invoke(
            nameof(ReturnToNormalShot),
            tripleShotDuration
        );
    }

    private void ReturnToNormalShot()
    {
        currentShoot = new BasicShootDecorator(
            null,
            BulletSpawnPoint,
            bulletSpeed
        );
    }
}