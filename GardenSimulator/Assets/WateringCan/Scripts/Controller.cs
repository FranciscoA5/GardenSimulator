using UnityEngine;

public class Controller : MonoBehaviour
{
   [SerializeField] private AudioClip pickupSound;

   public void OnPickup()
   {
      AudioSource.PlayClipAtPoint(pickupSound, transform.position);
   }

   private void OnTriggerEnter(Collider other)
   {
      OnPickup();
   }
}
