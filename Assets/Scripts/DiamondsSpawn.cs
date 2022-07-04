using UnityEngine;

[RequireComponent(typeof(SpawnOnPoints))]
[RequireComponent(typeof(Transform))]
public class DiamondsSpawn : MonoBehaviour
{
    [SerializeField] private Diamond _diamond;
    
    private SpawnOnPoints _spawnOnPoints;

    private void Start()
    {
        _spawnOnPoints = GetComponent<SpawnOnPoints>();
        _spawnOnPoints.Spawn(_diamond.gameObject);
    }
}
