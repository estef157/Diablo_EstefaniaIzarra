using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  interface IInteractuable
{
    //una interfaz es un listado de metodos que cumple todo aquello que en este caso sea interactuable. Ej interfaz da�able, un metodo q van tener todos los que sean da�ables.
    //cuando quieras a�adir una cualidad a un monto.
    //ej en el theforest tanto arbol como enemigo son da�ables por el hacha.
    public void Interactuar(Transform interactuador);





    
}
