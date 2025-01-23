using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Color originalColor;
    [SerializeField] private Color color;
    [SerializeField] private Renderer renderer;


    public void Change() 
    {
        renderer.material.color = color;
    }

    public void Revert()
    {
        renderer.material.color = originalColor;
    }
}
