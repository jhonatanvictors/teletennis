using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bola : Photon.MonoBehaviour
{
    private Vector3 direction;
    public float speed;

    
    //private int playerOneScore;
    
    //private int playerTwoScore;

    public Vector3 spawnPoint;

    public GameObject goalEffect;
    public GameObject goalEffect2;

    //public Text playerOneText;
    //public Text playerTwoText;

    public Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        //playerOneScore = 0;
        //playerTwoScore = 0;
        
        Invoke("comecar",2);
    }

    public void comecar(){
        this.direction = new Vector3 (1f,0f,1f);
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

        if (col.gameObject.name == "paredeSul"){
            //playerTwoScore++;
            Instantiate(goalEffect2, this.transform.position, Quaternion.identity);
            transform.position = spawnPoint;
            rend.enabled = true;
            
        } else {
            Instantiate(goalEffect, this.transform.position, Quaternion.identity);
        }
        
        if (col.gameObject.name == "paredeNorte"){
            //playerOneScore++;
            Instantiate(goalEffect2, this.transform.position, Quaternion.identity);
            transform.position = spawnPoint;
            rend.enabled = true;
        } else {
            Instantiate(goalEffect, this.transform.position, Quaternion.identity);
            
        }

        //if (col.gameObject.name == "jogador1"){
        //    this.rend.enabled = false;
        //} else if (col.gameObject.name == "jogador2"){
        //    this.rend.enabled = false;
        //}


    }

}
