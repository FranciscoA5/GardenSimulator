using UnityEngine;


namespace WateringCan.Scripts
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private ParticleSystem activeWaterParticles;
        [SerializeField] private ParticleSystem normalWaterParticles;
        [SerializeField] private ParticleSystem sprayWaterParticles;
        [SerializeField] private ParticleSystem fullAutoWaterParticles;
        [SerializeField] private float minPouringAngle = 36.0f;
        [SerializeField] private float maxPouringAngle = 270.0f;

        public void SetNormalMode() => SetWaterStreamParticles(normalWaterParticles);
        public void SetSprayMode() => SetWaterStreamParticles(sprayWaterParticles);
        public void SetFullAutoWaterMode() => SetWaterStreamParticles(fullAutoWaterParticles);

        private void SetWaterStreamParticles(in ParticleSystem newParticles)
        {
            activeWaterParticles.Stop();
            activeWaterParticles = newParticles;
        }

        private void StartWaterParticles() => activeWaterParticles.Play();
        private void StopWaterParticles() => activeWaterParticles.Stop();

        private void Update()
        {
            if (!activeWaterParticles.isPlaying && IsAtPouringAngle())
            {
                print("startwatering");
                StartWaterParticles();
                return;
            }

            if (!activeWaterParticles.isPlaying ||
                IsAtPouringAngle()) return;
            print("Stop");
            StopWaterParticles();
        }

        private bool IsAtPouringAngle()
        {
            return gameObject.transform.rotation.eulerAngles.x >= minPouringAngle &&
                   gameObject.transform.rotation.eulerAngles.x <= maxPouringAngle;
        }
    }
}