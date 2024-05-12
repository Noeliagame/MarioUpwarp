using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaManager : MonoBehaviour
{
    public GameObject CuadroPausa;
    public bool enPausa;


    public void PausarBoton()
    {

        enPausa = true;
        CuadroPausa.SetActive(true);
        Time.timeScale = 0.1f;
       
    }

    public void Continuar()
    {
        enPausa = false;  
        CuadroPausa.SetActive(false);
        Time.timeScale = 1f;

    }

}
