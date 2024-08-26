using UnityEngine;

public class Pulpit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Doofus"))
        {
            PulpitSpawner gameController = FindObjectOfType<PulpitSpawner>();
            
        }
    }
}
