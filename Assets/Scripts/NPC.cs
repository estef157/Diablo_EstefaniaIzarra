using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractuable
{
    private Outline outline;
    private EventManagerSO eventManager;
   
    [SerializeField] private DialogaSO dialogo1;
    [SerializeField] private DialogaSO dialogo2;
    [SerializeField] private float tiempoRotacion;
    [SerializeField] private MisionSO misionAsociada;
     private DialogaSO dialogoActual;
    [SerializeField] private Transform puntoCamara;
    private float lookAtDuration = 0.5f;
   
    private void Awake()
    {
        dialogoActual = dialogo1;
        
    }



    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if(misionTerminada == misionAsociada)
        {
            dialogoActual = dialogo2;
        }
    }

    public void Interactuar (Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete (() => SistemaDialogo.sistema.IniciarDialogo(dialogoActual, puntoCamara)); 
    }

    

    
}
