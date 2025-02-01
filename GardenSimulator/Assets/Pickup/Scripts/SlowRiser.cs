using UnityEngine;

namespace Pickup.Scripts
{
    public class SlowRiser : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private float duration = 0.5f;


        private Collider collider;
        private float _timer;

        private void Start()
        {
            collider = GetComponent<Collider>();
        }

        private void OnParticleCollision(GameObject other)
        {
            print("water collision");

            transform.position += Vector3.up * speed * Time.deltaTime;
            _timer += Time.deltaTime;

            if (_timer >= duration)
            {
                Destroy(this);
            }
        }

        private void OnDisable()
        {
            collider.isTrigger = true;
        }
    }
}