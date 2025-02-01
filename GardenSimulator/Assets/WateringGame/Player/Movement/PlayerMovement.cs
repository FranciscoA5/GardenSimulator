using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 15f;
    //float velocity = 0f;
    [SerializeField] GameObject player, centerEyeTracker;

    private void MovePlayer()
    {
        float velocity = Time.deltaTime * speed; // Increment t over time
        player.transform.position = Vector3.Lerp(player.transform.position, player.transform.position + centerEyeTracker.transform.forward, velocity);
        //player.transform.position += centerEyeTracker.transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PinchPoint")) MovePlayer();
    }
}
