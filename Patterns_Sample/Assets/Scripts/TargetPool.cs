using UnityEngine;

public class TargetPool : PoolBase<Target>
{
    public static TargetPool Instance;

    [SerializeField]
    private Target prefab;

    private void Awake()
    {
        Instance = this;
    }

    protected override Target CreateInstance()
    {
        return Instantiate(prefab);
    }
}