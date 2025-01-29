using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu (menuName = "Misión")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial; //recoge las setas...
    public string ordenFinal;//vuelve a hablar...

    public bool repeticion;//Si la misión tiene varios pasos. Por ejemplo necesitas recoger más de una seta.
    public int repeticionesTotales;//Necesitas 5 setas, se repite 5 veces
    [NonSerialized] public int pasoActual = 0; // por cual seta vas actualmente...
    public int indiceMision;//Identificador único.

}
