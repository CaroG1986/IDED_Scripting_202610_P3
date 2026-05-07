using UnityEngine;

public class TargetFactory : FactoryBase<Target>
{
    public Target CreateInstance(TargetType type)
    {
        return Instantiate(spawnObjects[(int)type]);
    }

    public override Target CreateInstance()
    {
        return Instantiate(
            spawnObjects[Random.Range(0, spawnObjects.Length)]
        );
    }
}