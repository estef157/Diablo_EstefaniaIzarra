using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private SistemaCombate sistemaCombate;

    private Transform mainTarget;

    private SistemaPatrulla sistemaPatrulla;

    public SistemaCombate SistemaCombate { get => sistemaCombate; set => sistemaCombate = value; }
    public SistemaPatrulla SistemaPatrulla { get => sistemaPatrulla; set => sistemaPatrulla = value; }
    public Transform MainTarget { get => mainTarget; }

    //encapsulamos para poder acceder a otros scripts ¿¿

    private void Start()
    {
        //Empieza el juego y activamos la patrulla
        sistemaPatrulla.enabled = true;
    }
    public void ActivaCombate(Transform target)
    {
        mainTarget = target;
        //nos dicen de activar el combate
         sistemaCombate.enabled = true;
    }
    


}
