using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Diamond : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Take(collision);
    }

    private void Take(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(_audioSource.clip,transform.position);
        }
    }
}
