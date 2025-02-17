using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractuable
{
    private Outline outline;
    [SerializeField] private EventManagerSO eventManager;
   
    [SerializeField] private DialogaSO dialogo1;
    [SerializeField] private DialogaSO dialogo2;
    [SerializeField] private float tiempoRotacion;
    [SerializeField] private MisionSO misionAsociada;
    private DialogaSO dialogoActual;
    [SerializeField] private Transform puntoCamara;
    private float lookAtDuration = 0.5f;
    [SerializeField] private Texture2D cursordeNpc;
    [SerializeField] private Texture2D cursordeIdl;

    public DialogaSO Dialogo2 { get => dialogo2; set => dialogo2 = value; }
    public DialogaSO DialogoActual { get => dialogoActual; set => dialogoActual = value; }

    private void Awake()
    {
        outline = GetComponent<Outline>();
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

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursordeNpc, Vector2.zero, CursorMode.Auto);
        outline.enabled = true;
    }


    private void OnMouseExit()
    {
        Cursor.SetCursor(cursordeIdl, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }



}
