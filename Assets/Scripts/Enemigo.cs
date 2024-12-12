using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private Transform ruta;
    private NavMeshAgent agent;
    List<Vector3> listadoPuntos = new List<Vector3>();//una lista a diferencia de un Array puede cambiar, puedes tener cero elementos y tu lo vas metiendo.

    private Vector3 destinoActual; //marca el destino al cual tenemos que ir.


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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
        agent.SetDestination(destinoActual);
        yield return null;//significa q vaya al siguiente frame, q espere lo minimo.
    }

    private void CalcularDestino()
    {
        //Aqui vamos a ver por que destino vas
        destinoActual = listadoPuntos[0];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
