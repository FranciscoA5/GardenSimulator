using UnityEngine;

namespace Player.Scripts
{
    public class Running : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Plant") || other.CompareTag("Water"))
            {
                transform.transform.position += transform.forward * speed * Time.deltaTime;
            } 
        }
    }
}