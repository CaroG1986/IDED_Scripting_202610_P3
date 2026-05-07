using UnityEngine;

public class LowTargetPool : PoolBase<Target>
{
    public static LowTargetPool Instance;

    private void Awake()
    {
        Instance = this;
    }

    protected override Target CreateInstance()
    {
        return ((TargetFactory)TargetFactory.Instance)
            .CreateInstance(TargetType.Low);
    }
}