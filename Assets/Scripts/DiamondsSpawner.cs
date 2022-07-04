using UnityEngine;

[RequireComponent(typeof(SpawnOnPoints))]
public class DiamondsSpawner : MonoBehaviour
{
    [SerializeField] private Diamond _diamond;
    
    private SpawnOnPoints _spawnOnPoints;

    private void Start()
    {
        _spawnOnPoints = GetComponent<SpawnOnPoints>();
        _spawnOnPoints.Spawn(_diamond.gameObject);
    }
}
