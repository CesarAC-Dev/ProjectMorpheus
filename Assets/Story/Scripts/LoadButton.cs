using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadButton : MonoBehaviour
{
    public GameData gameData;
    [SerializeField] Button botonNuevaPartida;
    [SerializeField] Button botonContinuar;
    [SerializeField] Button botonJugar;

    [SerializeField] Button textSure;
    [SerializeField] Button botonSureYes;
    [SerializeField] Button botonSureNo;
    private void Start()
    {
        gameData = DataSerializer.LoadGameData();
        if(gameData != null){
            botonNuevaPartida.gameObject.SetActive(true);
            botonContinuar.gameObject.SetActive(true);
            botonJugar.gameObject.SetActive(false);
        }else{
            botonNuevaPartida.gameObject.SetActive(false);
            botonContinuar.gameObject.SetActive(false);
            botonJugar.gameObject.SetActive(true);
        }
    }

    public void LoadNewGame()
    {
        
            SceneManager.LoadScene("SandBox");
        
    }
    public void Sure(){
            textSure.gameObject.SetActive(true);
            botonSureNo.gameObject.SetActive(true);
            botonSureYes.gameObject.SetActive(true);
            botonNuevaPartida.enabled = false;
            botonContinuar.enabled = false;
    }
    public void NotSure(){
            textSure.gameObject.SetActive(false);
            botonSureNo.gameObject.SetActive(false);
            botonSureYes.gameObject.SetActive(false);
            botonNuevaPartida.enabled = true;
            botonContinuar.enabled = true;
    }

    public void LoadGame()
    {   
        switch (gameData.place)
        {
            case 0:
                SceneManager.LoadScene("Room");
            break;
            case 1:
                SceneManager.LoadScene("Class");
            break;
            case 2:
                SceneManager.LoadScene(gameData.sceneName);
            break;
        }
    }
}
