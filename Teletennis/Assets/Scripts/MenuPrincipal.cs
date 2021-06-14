using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    //public void Jogar (){
    //    SceneManager.LoadScene(1);//No botão File > Build settings > Scenes in build dá pra //achar o número da cena
    //}

    public void Sair (){
        Debug.Log ("Teste SAIR");
        Application.Quit();
    }
}
