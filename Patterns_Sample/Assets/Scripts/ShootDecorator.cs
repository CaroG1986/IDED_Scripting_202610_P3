public abstract class ShootDecorator : IShoot
{
    protected IShoot shoot;

    public ShootDecorator(IShoot shoot)
    {
        this.shoot = shoot;
    }

    public virtual void Shoot()
    {
        shoot.Shoot();
    }
}
