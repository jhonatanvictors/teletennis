using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player1Prefab;
    public GameObject Player2Prefab;
    public GameObject BolaPrefab;
    public Text GamerTag1;
    public Text GamerTag2;

    public GameObject GameCanvas;
    public GameObject BotaoComecar;

    private void Awake() {
        GameCanvas.SetActive(true);
        BotaoComecar.SetActive(false);

        foreach (PhotonPlayer p in PhotonNetwork.playerList){
            string nickName = p.NickName;
            GamerTag1.text = GamerTag1.text + "\n " + nickName;
        }
    }
    

    public void SpawnPlayer1(){
        PhotonNetwork.Instantiate(Player1Prefab.name, new Vector3(0f,1.20999992f,-12f), Quaternion.identity, 0);
        

    }

    public void SpawnPlayer2(){
        PhotonNetwork.Instantiate(Player2Prefab.name, new Vector3(0f,1.20999992f,12f), Quaternion.identity, 0);
    }

    public void SpawnPlayer(){//Spawna a bolinha
        PhotonNetwork.Instantiate(BolaPrefab.name, new Vector3(0f,1.09200001f,0f), Quaternion.identity, 0);
    }

//Fim
}
//Posição player 1: Vector3(0,1.20999992,-12)
//Posição player 2: Vector3(0,1.20999992,12) 
//Posição bola: Vector3(0,1.09200001,0)