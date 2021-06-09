using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    
    void Start()
    {
        if (GameIsPaused){
            Resume();
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
        //Há um peçado de código no script da bolinha que pausa ela também, o comportamento dela é um pouco estranho

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        //No botão File > Build settings > Scenes in build dá pra achar o número da cena
    }

    public void QuitGame(){
        Debug.Log ("Teste SAIR");
        Application.Quit();
    }
}
