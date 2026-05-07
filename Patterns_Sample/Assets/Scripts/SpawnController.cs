using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 1f;

    [SerializeField]
    private float firstSpawnDelay = 0f;

    private Vector3 spawnPoint;

    private void Start()
    {
        if (TargetFacade.Instance != null)
        {
            InvokeRepeating(
                nameof(SpawnObject),
                firstSpawnDelay,
                spawnRate
            );

            if (Player.Instance != null)
            {
                Player.Instance.OnPlayerDied +=
                    StopSpawning;
            }
        }
    }

    private void SpawnObject()
    {
        spawnPoint =
            Camera.main.ViewportToWorldPoint(
                new Vector3(
                    Random.Range(0f, 1f),
                    1f,
                    transform.position.z
                )
            );

        
        TargetType randomType =
            (TargetType)Random.Range(0, 3);

        
        Target target =
            TargetFacade.Instance.GetTarget(
                randomType
            );

        if (target != null)
        {
            target.transform.position =
                spawnPoint;

            target.transform.rotation =
                Quaternion.identity;
        }
    }

    private void StopSpawning()
    {
        CancelInvoke();
    }
}