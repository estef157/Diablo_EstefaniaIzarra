using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour, IInteractuable 
{
    private Outline outline;
    [SerializeField] private Texture2D cursorDefecto;
    [SerializeField] private Texture2D cursorInteraccion;
    // Start is called before the first frame update

    private void Awake()
    {
        //El awake viene antes del Start, es una única vez al
        //igual que el Start. Esté el script habilitado o no, el awake
        //se lanza igual, el start no.
        outline = GetComponent<Outline>();
    }
    public void Interactuar()
    {
      
    }

    
    void Update()
    {
        
    }

    private void OnMouseEnter()//cuando pasamos el ratón por encima
    {
        Cursor.SetCursor(cursorInteraccion, Vector2.zero,CursorMode.Auto);
        outline.enabled = true;
    }

    private void OnMouseExit()//cuando quitamos el ratón

    {
        Cursor.SetCursor(cursorDefecto, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }

    public void Interactuar(Transform interactuador)
    {
        throw new System.NotImplementedException();
    }
}
