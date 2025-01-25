using UnityEngine;

namespace Pickup.Scripts
{
    public class SlowRiser : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private float popStrength = 1.0f;

        private Rigidbody _rb;
        private float _timer;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.useGravity = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Water")) return;
            
            _rb.transform.position += Vector3.up * speed * Time.deltaTime;
            _timer += Time.deltaTime;
            
            if (_timer >= duration)
            {
                Destroy(this);
            }
        }

        private void OnDisable()
        {
            _rb.AddForce(Vector3.up * popStrength, ForceMode.Impulse);
        }
    }
}