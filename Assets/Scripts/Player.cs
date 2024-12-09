using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    [SerializeField] private float velocidad;
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
       
        Movimiento();
        if (ultimoClick && ultimoClick.TryGetComponent(out NPC npc))
        {
            //agent.stoppingDistance = distanciaInteraccion;
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                {
                    npc.Interactuar(this.transform);
                    ultimoClick = null;
                  

                }
            }
        }
        else if (ultimoClick)
        {
            agent.stoppingDistance = 0f;
        }

    }
        void Movimiento()
        {
            //trazar un raycast desde la cámara a la posición del ratón.
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
