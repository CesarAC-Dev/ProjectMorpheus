using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarSolucion : MonoBehaviour
{
    private bool[] piezas = {false, false, false, false, false, false, false};

    public void ToFalse(int id)
    {
        piezas[id] = false;
    }

    public void Comprobar(Vector3 vector, int id)
    {
        switch(id)
        {
            case 0:
                if(vector == new Vector3(-1, -2))
                {
                    piezas[0] = true;
                }
                else
                {
                    piezas[0] = false;
                }
                break;
            case 1:
                if(vector == new Vector3(0, -1))
                {
                    piezas[1] = true;
                }
                else
                {
                    piezas[1] = false;
                }
                break;
            default:
                break;
        }

        bool resuelto = true;

        for(int i = 0; i < piezas.Length; i++)
        {
            if(piezas[i] == false)
            {
                resuelto = false;
                break;
            }
        }
        
        if(resuelto == true)
        {
            Debug.Log("RESUELTO SIUUUUUUUUU");
        }
    }
}
