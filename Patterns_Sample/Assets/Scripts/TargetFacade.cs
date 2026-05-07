using UnityEngine;

public class TargetFacade : MonoBehaviour
{
    public static TargetFacade Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Target GetTarget(TargetType type)
    {
        switch (type)
        {
            case TargetType.High:
                return HighTargetPool.Instance.Get();

            case TargetType.Mid:
                return MidTargetPool.Instance.Get();

            case TargetType.Low:
                return LowTargetPool.Instance.Get();
        }

        return null;
    }

    public void ReturnTarget(Target target)
    {
        switch (target.TargetType)
        {
            case TargetType.High:
                HighTargetPool.Instance.Return(target);
                break;

            case TargetType.Mid:
                MidTargetPool.Instance.Return(target);
                break;

            case TargetType.Low:
                LowTargetPool.Instance.Return(target);
                break;
        }
    }
}