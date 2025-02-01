using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGameState : MonoBehaviour
{
    [SerializeField] GameState state;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PinchPoint"))
        {
            GameController.gameController.UpdateGameState(state);
        }

        else if (other.gameObject.CompareTag("Seed") && GameController.gameController.gameState == GameState.Planting)
        {
            GameController.gameController.UpdateGameState(state);
            Destroy(other.gameObject);
        }

        else if(other.gameObject.CompareTag("Plant") && GameController.gameController.gameState == GameState.Disposing)
        {
            GameController.gameController.UpdateGameState(state);
            GameController.gameController.points += 1;

            Destroy(other.gameObject);
        }
    }
}
