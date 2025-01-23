using System;
using UnityEngine;


namespace WateringCan.Scripts
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private ParticleSystem activeWaterParticles; 
        [SerializeField] private ParticleSystem normalWaterParticles;
        [SerializeField] private ParticleSystem sprayWaterParticles;
        [SerializeField] private ParticleSystem fullAutoWaterParticles;
       
        private bool _isPlaying;
        public void SetNormalMode() => activeWaterParticles = normalWaterParticles;
        public void SetSprayMode() => activeWaterParticles = sprayWaterParticles;
        public void SetFullAutoWaterMode() => activeWaterParticles = fullAutoWaterParticles;
        private void StartWaterParticles() => activeWaterParticles.Play();
        private void StopWaterParticles() => activeWaterParticles.Stop();

        private void Update()
        {
            if (transform.rotation.x is > 36.0f and < 270.0f && !_isPlaying)
            {
                StartWaterParticles();
                Debug.Log("Starting water particles");
                _isPlaying = true;
            }
            else
            {
                StopWaterParticles();
                Debug.Log("Stopping water particles");
                _isPlaying = false;
            }
        }
    }
}