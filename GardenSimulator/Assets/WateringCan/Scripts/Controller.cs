using UnityEngine;


namespace WateringCan.Scripts
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private ParticleSystem activeWaterParticles; 
        [SerializeField] private ParticleSystem normalWaterParticles;
        [SerializeField] private ParticleSystem sprayWaterParticles;
        [SerializeField] private ParticleSystem fullAutoWaterParticles;
       
        public void SetNormalMode() => activeWaterParticles = normalWaterParticles;
        public void SetSprayMode() => activeWaterParticles = sprayWaterParticles;
        public void SetFullAutoWaterMode() => activeWaterParticles = fullAutoWaterParticles;
        public void StartWaterParticles() => activeWaterParticles.Play();
        public void StopWaterParticles() => activeWaterParticles.Stop();
    }
}