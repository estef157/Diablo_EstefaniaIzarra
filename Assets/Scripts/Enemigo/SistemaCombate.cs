using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    //Primero awake, luego oneable que puede ser varias veces y luego start.
    
    [SerializeField] float velocidadCombate;
    [SerializeField] Animator anim;
    [SerializeField] float danhoAtaque;
    [SerializeField] float distanciaAtaque;
    [SerializeField] NavMeshAgent movAgent;
    [SerializeField] Enemigo main;
    // Start is called before the first frame update

    
    private void Awake()
    {
        main.SistemaCombate = this;
        
    }
    private void OnEnable() //el combate ha sido habilitado
    {
        movAgent.speed = velocidadCombate;
        movAgent.stoppingDistance = 0;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(main.MainTarget != null && movAgent.CalculatePath(main.MainTarget.position, new NavMeshPath()))//si el target es alcanzable
        {
            EnfocarObjetivo();
            movAgent.SetDestination (main.MainTarget.position);

            if(movAgent.remainingDistance <= distanciaAtaque)
            {
                anim.SetBool("atacando", true);
            }
        }
        else // Y si no lo es......
        {
            main.activarPatrulla();
        }
        
        movAgent.SetDestination(main.MainTarget.position);
    }

    private void EnfocarObjetivo()
    {
       Vector3 direccionATarget = (main.MainTarget.position - this.transform.position).normalized;
        direccionATarget.y = 0;
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);
        transform.rotation = rotacionATarget;
    }
}
