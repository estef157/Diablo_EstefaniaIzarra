using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Manager")]
public class EventManagerSO : ScriptableObject

    
{

    public event Action<MisionSO> OnNuevaMision;//Evento
    public event Action<MisionSO> OnActualizarMision;
    public event Action<MisionSO> OnTerminarMision;

    internal void NuevaMision(MisionSO mision)
    {
        //vamos a lanzar notificaciones aka el evento por si a alguien le interesa. Ej al toggle para q se active.
        OnNuevaMision?.Invoke(mision);
        //? se asegura de que la invocación sea segura y tenga subscriptores.
    }

    public void ActualizarMision(MisionSO mision)
    {
        OnActualizarMision?.Invoke(mision);
    }
    public void TerminarMision(MisionSO mision)
    {
        OnTerminarMision?.Invoke(mision);
    }
}
