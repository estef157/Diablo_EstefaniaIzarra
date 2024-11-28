using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private Texture2D cursorDefecto;
    [SerializeField] private Texture2D cursorInteraccion;
    // Start is called before the first frame update

    private void Awake()
    {
        //El awake viene antes del Start, es una �nica vez al
        //igual que el Start. Est� el script habilitado o no, el awake
        //se lanza igual, el start no.
        outline = GetComponent<Outline>();
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()//cuando pasamos el rat�n por encima
    {
        Cursor.SetCursor(cursorInteraccion, Vector2.zero,CursorMode.Auto);
        outline.enabled = true;
    }

    private void OnMouseExit()//cuando quitamos el rat�n

    {
        Cursor.SetCursor(cursorDefecto, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }
}
