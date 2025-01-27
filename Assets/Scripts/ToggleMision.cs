using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToggleMision : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoMision;//textos de cada mision

    private Toggle toggle;

    public TMP_Text TextoMision { get => textoMision;  }

    public Toggle Toggle { get => toggle; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
