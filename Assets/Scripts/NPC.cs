using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private DialogaSO dialogo;
    [SerializeField] private float tiempoRotacion;
    [SerializeField] private Transform cameraPoint;
    // Start is called before the first frame update
    private void Awake()
    {
        
        outline = GetComponent<Outline>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interactuar (Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete (() => SistemaDialogo.sistema.IniciarDialogo(dialogo, cameraPoint)); 
    }

    private void OnMouseEnter()//cuando pasamos el ratón por encima
    {
        outline.enabled = true;
    }

    private void OnMouseExit()//cuando quitamos el ratón

    {
        
        outline.enabled = false;
    }
}
