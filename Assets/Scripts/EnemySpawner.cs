using UnityEngine;

[RequireComponent(typeof(SpawnOnPoints))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private SpawnOnPoints _spawnOnPoints;

    private void Start()
    {
        _spawnOnPoints = GetComponent<SpawnOnPoints>();
        _spawnOnPoints.Spawn(_enemy.gameObject);
    }
}
