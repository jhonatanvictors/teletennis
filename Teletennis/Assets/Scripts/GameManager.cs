using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    //A maioria desses não está sendo usada, está aqui para usar depois.

    public GameObject HudGame;
    public GameObject PrefabPlayer;
    //public GameObject MenuOptions;
    //public GameObject MenuCamera;

    //...

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Irrelevante por enquanto, deixando aqui pra prevenir erros, ou causar eles.
    void UpdateUI(bool InGame){
        if (InGame == true){
            HudGame.SetActive(true);
            //MenuOptions.SetActive(false);
            //MenuCamera.SetActive(false);
        } else {
            HudGame.SetActive(false);
            //MenuOptions.SetActive(true);
            //MenuCamera.SetActive(true);
        }
    }

    //Não faço a mínima ideia se isso vai servir pra algo
    public void _Offline(){
        Instantiate(PrefabPlayer, Vector3.zero, Quaternion.identity);
        UpdateUI(true);

    }

    //Configuração do multijogador
    public void _Connect(){
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster(){
        PhotonNetwork.JoinRandomRoom();
        base.OnConnectedToMaster();
    }

    public override void OnJoinRandomFailed (short returnCode, string message){
        PhotonNetwork.CreateRoom ("sala" + Random.Range(0,1000).ToString());
        base.OnJoinRandomFailed (returnCode, message);
    }

    public override void OnJoinedRoom(){
        var player = PhotonNetwork.Instantiate("jogador1Multiplayer", Vector3.zero, Quaternion.identity);
        player.GetComponent<jogador1>().enabled = true;
        UpdateUI(true);
        base.OnJoinedRoom();
    }
    
    public override void OnDisconnected (Photon.Realtime.DisconnectCause cause){
        UpdateUI(false);
        base.OnDisconnected(cause);
    }
}
