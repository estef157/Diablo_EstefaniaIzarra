using System.Collections;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    private EventManagerSO eventManager;
    [SerializeField] private GameObject marco;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField] private Transform npcCamera;


    private bool escribiendo; //Determina si el sistema está escribiendo o no.
    private int indiceFraseActual;//marca la frase actual
    private DialogaSO dialogoActual;
    public static SistemaDialogo sistema;

    void Awake()
    {
        if (sistema == null)
        {
            sistema = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    
   

    public void IniciarDialogo(DialogaSO dialogo, Transform cameraPoint)
   {
       Time.timeScale = 0f;
       npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);
      //  El diálogo actual con el que trabajamos es el que me dan por parámetro de entrada.
        dialogoActual = dialogo;
       marco.SetActive(true);
        StartCoroutine(EscribirFrase());
   }

    //Que el texto aparezca letra por letra
    private IEnumerator EscribirFrase()
    {
      escribiendo = true;

        textoDialogo.text = "";
        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();
        foreach (char letra in fraseEnLetras)
        {
            textoDialogo.text += letra;
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        }
        //este bool aka escribiendo 
        escribiendo = false;
    }
    public void SiguienteFrase()
    {
        if (escribiendo)//si ya estamos escribiendo una frase...
        {
            CompletarFrase();
        }
        else
        {
            indiceFraseActual++;
            if (indiceFraseActual < dialogoActual.frases.Length)
            {
                StartCoroutine(EscribirFrase());
            }
            else
            {
                TerminarDialogo();
            }
            StartCoroutine(EscribirFrase());
        }
    }
    private void CompletarFrase()
    {
        StopAllCoroutines();
        //textoDialogo.text = dialogoActual.frases(indiceFraseActual);
        escribiendo = false;
    }
    private void TerminarDialogo()
    {
        Time.timeScale = 1f;
        marco.SetActive(false);
        
        indiceFraseActual = 0;
        escribiendo = false;

        StopAllCoroutines();
        if (dialogoActual.tieneMision)
        {
            eventManager.NuevaMision();
        }
        dialogoActual = null;
    }

}
