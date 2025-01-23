using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Manager")]
public class EventManagerSO : ScriptableObject
{
    public event Action OnNuevaMision;//Evento

    internal void NuevaMision()
    {
        //vamos a lanzar notificaciones aka el evento por si a alguien le interesa. Ej al toggle para q se active.
        OnNuevaMision.Invoke();

    }
}
