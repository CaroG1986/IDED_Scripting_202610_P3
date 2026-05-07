using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Target : MonoBehaviour,
    IFactoryProduct,
    IPoolable
{
    private const float TIME_TO_DESTROY = 10F;

    [SerializeField]
    private int maxHP = 1;

    private int currentHP;

    [SerializeField]
    private TargetType targetType;

    public TargetType TargetType => targetType;

    [SerializeField]
    private int scoreAdd = 10;

    public delegate void OnTargetDestroyed(int scoreAdd);

    public static event OnTargetDestroyed onTargetDestroyed;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void ResetObject(bool active)
    {
        gameObject.SetActive(active);

        currentHP = maxHP;

        CancelInvoke();

        if (active)
        {
            Invoke(nameof(ReturnToPool), TIME_TO_DESTROY);
        }
    }

    private void ReturnToPool()
    {
        TargetFacade.Instance.ReturnTarget(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int collidedObjectLayer = collision.gameObject.layer;

        if (collidedObjectLayer.Equals(Utils.BulletLayer))
        {
            Pool.Instance.ReturnBullet(
                collision.gameObject.GetComponent<Bullet>()
            );

            currentHP -= 1;

            if (currentHP <= 0)
            {
                onTargetDestroyed?.Invoke(scoreAdd);

                ReturnToPool();
            }
        }
        else if (
            collidedObjectLayer.Equals(Utils.PlayerLayer) ||
            collidedObjectLayer.Equals(Utils.KillVolumeLayer)
        )
        {
            Player.Instance.OnPlayerHit?.Invoke();

            ReturnToPool();
        }
    }
}