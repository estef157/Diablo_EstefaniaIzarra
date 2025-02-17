using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaDialogo : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private GameObject marco;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField] private Transform npcCamera;


    private bool escribiendo; //Determina si el sistema está escribiendo o no.
    private int indiceFraseActual;//marca la frase actual
    private DialogaSO dialogo;
    private NPC npc;
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
        this.dialogo = dialogo;
       marco.SetActive(true);
        StartCoroutine(EscribirFrase());
   }

    //Que el texto aparezca letra por letra
    private IEnumerator EscribirFrase()
    {
      escribiendo = true;

        textoDialogo.text = "";
        char[] fraseEnLetras = dialogo.frases[indiceFraseActual].ToCharArray();
        foreach (char letra in fraseEnLetras)
        {
            textoDialogo.text += letra;
            yield return new WaitForSecondsRealtime(dialogo.tiempoEntreLetras);
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
            if (indiceFraseActual < dialogo.frases.Length)
            {
                StartCoroutine(EscribirFrase());
            }
            else
            {
                TerminarDialogo();
            }
           
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
        if (dialogo.tieneMision)
        {
            //Comunico al event manager que hay una mision en este diálogo
            eventManager.NuevaMision(dialogo.mision);

        }
        if (npc.DialogoActual == npc.Dialogo2)
        {
            SceneManager.LoadScene(3);
        }
        dialogo = null;
    }

}
