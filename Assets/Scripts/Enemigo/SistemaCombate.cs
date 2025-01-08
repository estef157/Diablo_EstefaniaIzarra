using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    
    [SerializeField] float velocidadCombate;
    [SerializeField] NavMeshAgent movAgent;
    [SerializeField] Enemigo main;
    // Start is called before the first frame update

    
    private void Awake()
    {
        main.SistemaCombate = this;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movAgent.speed = velocidadCombate;
        movAgent.SetDestination(main.MainTarget.position);
    }
}
