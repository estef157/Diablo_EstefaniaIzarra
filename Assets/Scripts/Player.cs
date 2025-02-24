using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private float tiempoRotacion;
    NavMeshAgent agent;
    private Camera cam;
    //Guarda info del npc con que interactuas
    private Transform ultimoClick;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
         if(Time.timeScale ==1)
        {
            Movimiento();
        }


   
        if (ultimoClick && ultimoClick.TryGetComponent(out IInteractuable interactuable))
        {
           
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                {
                    LanzarInteraccion(interactuable);
                 
          
                }
            }
        }
        else if (ultimoClick)
        {
            agent.stoppingDistance = 0f;
        }

    }

    private void LanzarInteraccion(IInteractuable interactuable)
    {
        interactuable.Interactuar(transform);
        ultimoClick = null;
    }
    void Movimiento()
    {
           //trazar un raycast desde la c�mara a la posici�n del rat�n.
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ultimoClick = hit.transform;
                    agent.SetDestination(hit.point);
                }



            }


    }


   }
