using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    
    [SerializeField] private Enemigo main;
    [SerializeField] private Transform ruta;
    [SerializeField] private float velocidadPatrulla;
    [SerializeField] private NavMeshAgent agent;
    List<Vector3> listadoPuntos = new List<Vector3>();//una lista a diferencia de un Array puede cambiar, puedes tener cero elementos y tu lo vas metiendo.

    private Vector3 destinoActual; //marca el destino al cual tenemos que ir.
    private int indiceRutaActual = -1; //marca el indice del nuevo punto.

    private void Awake()
    {
        main.SistemaPatrulla = this;//comunico al main que el sistema de patrulla soy yo.

        //voy recorriendo todos los puntos que tiene mi ruta...
        foreach (Transform punto in ruta)
        {
            //y los añado en mi lista
            listadoPuntos.Add(punto.position);
        }
        CalcularDestino();
    }
    void Start()
    {
        
        
    }

    private void OnEnable()
    {
        indiceRutaActual += -1; //empiezo la ruta desde el comienzo
        agent.speed = velocidadPatrulla; //vuelvo a la vel de patrulla
        StartCoroutine(PatrullarYEsperar()); //vuelve la corrutina
    }
    private IEnumerator PatrullarYEsperar()
    {
        while(true)
        {
            CalcularDestino();//calculame un nuevo destino
            agent.SetDestination(destinoActual);//Se te marca dicho destino
            yield return new WaitUntil( ()=> !agent.pathPending && agent.remainingDistance <= 0.2f); ;//Espera a llegar a dicho destino y repites. ()=> obligatorio, metodo anonimo. el waituntil te pide una funcion con bool

            yield return new WaitForSeconds(Random.Range(0.25f, 3f));
        }
        
    }

    private void CalcularDestino()
    {
        indiceRutaActual++;///avanzas 1 en el indice
        if(indiceRutaActual >= listadoPuntos.Count)
        {
            //Si no me quedan puntos, volveré al punto 0.
            indiceRutaActual = 0;
        }
        destinoActual = listadoPuntos[indiceRutaActual]; //Aqui vamos a ver por que destino vas
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            main.ActivaCombate(other.transform);//ctrl + click
            this.enabled = false;//quito patrulla
            StopAllCoroutines();//paro corrutinas
            
            
        }
    }
}
