using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Dialogo")]
public class DialogaSO : ScriptableObject
{
    [TextArea]
    public string[] frases;
    public float tiempoEntreLetras;



    public bool tieneMision;
    public MisionSO mision;
}
