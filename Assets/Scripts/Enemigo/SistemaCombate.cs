using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    //Primero awake, luego oneable que puede ser varias veces y luego start.
    
    [SerializeField] float velocidadCombate;
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
        movAgent.stoppingDistance = distanciaAtaque;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        movAgent.SetDestination(main.MainTarget.position);
    }
}
