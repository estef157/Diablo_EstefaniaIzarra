using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  interface IInteractuable
{
    //una interfaz es un listado de metodos que cumple todo aquello que en este caso sea interactuable. Ej interfaz dañable, un metodo q van tener todos los que sean dañables.
    //cuando quieras añadir una cualidad a un monto.
    //ej en el theforest tanto arbol como enemigo son dañables por el hacha.
    public void Interactuar(Transform interactuador);





    
}
