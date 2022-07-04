using UnityEngine;

public class SpawnOnPoints : MonoBehaviour
{
    private GameObject _template;
    private Transform[] _points;

    public void Spawn(GameObject template)
    {
        _points = new Transform[transform.childCount];
        _template = template;
        
        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }
        
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject newObject = Instantiate(_template, Vector3.zero, Quaternion.identity);
            Transform newObjectTransform = newObject.GetComponent<Transform>();

            newObjectTransform.position = _points[i].position;
        }
    }
}
