using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bola : Photon.MonoBehaviour
{
    private Vector3 direction;
    public float speed;
    public float direcao;

    //Referencia os sons
    public AudioSource sound0;
    public AudioSource sound1;
    
    //private int playerOneScore;
    
    //private int playerTwoScore;

    public Vector3 spawnPoint;
    public GameObject goalEffect;
    public GameObject goalEffect2;

    //public Text playerOneText;
    //public Text playerTwoText;

    //public Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        //Sistema de som
        

        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        //playerOneScore = 0;
        //playerTwoScore = 0;
        direcao = 1f;
        Invoke("comecar",2);
    }

    public void roleta(){
        if (direcao == 1f){
            this.direction = new Vector3 (1f,0f,1f);
            direcao++;
        } else if (direcao == 2f){
            this.direction = new Vector3 (1f,0f,-1f);
            direcao++;
        } else if (direcao == 3f){
            this.direction = new Vector3 (-1f,0f,1f);
            direcao++;
        } else {
            this.direction = new Vector3 (-1f,0f,-1f);
            direcao = 1f;
        }
    }


    public void comecar(){
        roleta();
        
    }

    public void PlaySound0()
    {
        sound0.Play();
    }

    public void PlaySound1()
    {
        sound1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuPausa.GameIsPaused){} else {

            this.transform.position += direction * speed;
            //playerOneText.text = playerOneScore.ToString();
            //playerTwoText.text = playerTwoScore.ToString();
            
        }
        
    }

    void OnCollisionEnter(Collision col) 
    {
        Vector3 normal = col.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);
        speed = speed * 1.01f;

        if (col.gameObject.name == "paredeSul"){
            //playerTwoScore++;
            Instantiate(goalEffect2, this.transform.position, Quaternion.identity);
            transform.position = spawnPoint;
            this.direction = new Vector3 (0f,0f,0f);
            Invoke("comecar",1);
            PlaySound1();

            //rend.enabled = true;
            
        }
        
        if (col.gameObject.name == "paredeNorte"){
            //playerOneScore++;
            Instantiate(goalEffect2, this.transform.position, Quaternion.identity);
            transform.position = spawnPoint;
            this.direction = new Vector3 (0f,0f,0f);
            Invoke("comecar",1);
            PlaySound1();

            //rend.enabled = true;
        } 
        
        if (col.gameObject.name != "paredeNorte" && col.gameObject.name != "paredeSul") {
            Instantiate(goalEffect, this.transform.position, Quaternion.identity);
            PlaySound0();
        }

        //if (col.gameObject.name == "jogador1"){
        //    this.rend.enabled = false;
        //} else if (col.gameObject.name == "jogador2"){
        //    this.rend.enabled = false;
        //}


    }

}
