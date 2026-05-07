using UnityEngine;

public class MidTargetPool : PoolBase<Target>
{
    public static MidTargetPool Instance;

    private void Awake()
    {
        Instance = this;
    }

    protected override Target CreateInstance()
    {
        return ((TargetFactory)TargetFactory.Instance)
           .CreateInstance(TargetType.Mid);
    }
}