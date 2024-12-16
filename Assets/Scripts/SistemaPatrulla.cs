using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;
    [SerializeField] private NavMeshAgent agent;
    List<Vector3> listadoPuntos = new List<Vector3>();//una lista a diferencia de un Array puede cambiar, puedes tener cero elementos y tu lo vas metiendo.

    private Vector3 destinoActual; //marca el destino al cual tenemos que ir.
    private int indiceRutaActual = -1; //marca el indice del nuevo punto.

    private void Awake()
    {
       
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
        StartCoroutine(PatrullarYEsperar());
    }

    private IEnumerator PatrullarYEsperar()
    {
        while(true)
        {
            CalcularDestino();//calculame un nuevo destino
            agent.SetDestination(destinoActual);//Se te marca dicho destino
            yield return new WaitUntil( ()=> !agent.pathPending && agent.remainingDistance <= 0.2f); ;//Espera a llegar a dicho destino y repites.
        }
        
    }

    private void CalcularDestino()
    {
        indiceRutaActual++;
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
}
