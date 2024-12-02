using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcultaParedes : MonoBehaviour
{

    [SerializeField] private Renderer [] paredes;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Renderer pared in paredes)
            {
                Color nuevoColor = pared.material.color;
                nuevoColor.a = 0.2f;
                pared.material.color = nuevoColor;
                pared.enabled = false;
            }
        }
    }
}
