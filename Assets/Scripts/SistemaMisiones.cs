using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField]
    private EventManagerSO eventManager;
    [SerializeField]
    private ToggleMision[] toggleMision;  

    private void OnEnable()
    {
        eventManager.OnNuevaMision += ActivarToggleMision;
        eventManager.OnActualizarMision += ActualizarToggle;
        eventManager.OnTerminarMision += CerrarToggle;
    }


    private void ActivarToggleMision(MisionSO mision)
    {
        toggleMision[mision.indiceMision].TextoMision.text= mision.ordenInicial;

        if(mision.repeticion)
        {
            toggleMision[mision.indiceMision].TextoMision.text += "(" + mision.pasoActual + "/" + mision.repeticionesTotales + ")";
        }
        toggleMision[mision.indiceMision].gameObject.SetActive(true);


       toggleMision[mision.indiceMision].gameObject.SetActive(true);
    }
    private void ActualizarToggle(MisionSO mision)
    {
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        toggleMision[mision.indiceMision].TextoMision.text += "(" + mision.pasoActual + "/" + mision.repeticionesTotales + ")";
    }
    private void CerrarToggle(MisionSO mision)
    {
        //Marcar el toggle como true
        toggleMision[mision.indiceMision].Toggle.isOn = true;
        toggleMision[mision.indiceMision].TextoMision.text = mision.ordenFinal;
    }
}
