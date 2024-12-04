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
    private NPC npcActual;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        //trazar un raycast desde la cámara a la posición del ratón.
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast (ray, out RaycastHit hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                //Mirar si el punto donde he impactado tiene el script NPC
                if (hit.transform.TryGetComponent(out NPC npc))
                {
                    npcActual = npc;
                }
                agent.SetDestination(hit.point);
            }
            

        }
    }
}
