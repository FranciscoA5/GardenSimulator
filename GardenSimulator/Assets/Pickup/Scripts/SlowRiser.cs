using UnityEngine;

namespace Pickup.Scripts
{
    public class SlowRiser : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private float duration = 0.5f;

        private Animator _animator;
        private float _timer;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Water")) return;

            transform.position += Vector3.up * speed * Time.deltaTime;
            _timer += Time.deltaTime;

            if (_timer >= duration)
            {
                Destroy(this);
            }
        }

        private void OnDisable()
        {
            _animator.Play("PlantAnim");
        }
    }
}