using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGameState : MonoBehaviour
{
    [SerializeField] GameState state;
    [SerializeField] GameObject vase, cokePrefab, sunFlowerPrefab, lollyPopPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PinchPoint"))
        {
            GameController.gameController.UpdateGameState(state);
        }

        else if (other.gameObject.CompareTag("Seed") && GameController.gameController.gameState == GameState.Planting)
        {
            if (!other.gameObject.GetComponent<SeedPacketType>()) return;
            InstantiatePlant(other.gameObject.GetComponent<SeedPacketType>().type);
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

    private void InstantiatePlant(PlantType plantType)
    {
        switch (plantType) 
        {
            case PlantType.Coke:
                Instantiate(cokePrefab, vase.transform);
                break;
            case PlantType.SunFlower:
                Instantiate(sunFlowerPrefab, vase.transform);
                break;
            case PlantType.LollyPop:
                Instantiate(lollyPopPrefab, vase.transform);
                break;

        }
    }
}

public enum PlantType
{
    Coke, 
    SunFlower,
    LollyPop
}
