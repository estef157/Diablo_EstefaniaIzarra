using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Seta : MonoBehaviour, IInteractuable
{
    private Outline outline;
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private MisionSO misionAsociada;
    public void Interactuar(Transform interactuador)
    {
        misionAsociada.pasoActual++;
        if(misionAsociada.pasoActual < misionAsociada.repeticionesTotales)
        {
            eventManager.ActualizarMision(misionAsociada);
        }
        else
        {
            eventManager.TerminarMision(misionAsociada);
        }
        
        Destroy(this.gameObject);
        
    }

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    private void OnMouseEnter()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
