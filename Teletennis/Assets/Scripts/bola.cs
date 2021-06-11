using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Photon.Pun;

public class bola : MonoBehaviour //Antigo
//public class bola : MonoBehaviourPunCallbacks
{
    private Vector3 direction;
    public float speed;

    [SerializeField]
    private int playerOneScore;
    [SerializeField]
    private int playerTwoScore;

    public Vector3 spawnPoint;

    public GameObject goalEffect;

    public Text playerOneText;
    public Text playerTwoText;


    // Start is called before the first frame update
    void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        this.direction = new Vector3 (1f,0f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuPausa.GameIsPaused){} else {

            this.transform.position += direction * speed;
            playerOneText.text = playerOneScore.ToString();
            playerTwoText.text = playerTwoScore.ToString();
            
        }
        
    }

    void OnCollisionEnter(Collision col) 
    {
        Vector3 normal = col.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);

        if (col.gameObject.name == "paredeSul"){
            playerTwoScore++;
            Instantiate(goalEffect, this.transform.position, Quaternion.identity);
            transform.position = spawnPoint;
        }
        
        if (col.gameObject.name == "paredeNorte"){
            playerOneScore++;
            Instantiate(goalEffect, this.transform.position, Quaternion.identity);
            transform.position = spawnPoint;
        }
        
    }


}
