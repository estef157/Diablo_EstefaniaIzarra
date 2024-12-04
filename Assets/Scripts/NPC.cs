using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private float tiempoRotacion;
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
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y); 
    }

    private void OnMouseEnter()//cuando pasamos el rat�n por encima
    {
        outline.enabled = true;
    }

    private void OnMouseExit()//cuando quitamos el rat�n

    {
        
        outline.enabled = false;
    }
}
