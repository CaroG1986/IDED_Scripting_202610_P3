using UnityEngine;

public class HighTargetPool : PoolBase<Target>
{
    public static HighTargetPool Instance;

    private void Awake()
    {
        Instance = this;
    }

    protected override Target CreateInstance()
    {
        return ((TargetFactory)TargetFactory.Instance)
            .CreateInstance(TargetType.High);
    }
}