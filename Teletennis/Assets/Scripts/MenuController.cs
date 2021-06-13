using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string VersioName = "0.1";
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;

    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject StartButton;

    private void Awake() {
        PhotonNetwork.ConnectUsingSettings(VersioName);
    }

    private void Start() {
        UsernameMenu.SetActive(true);
    }

    private void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    public void ChangeUserNameInput(){
        if(UsernameInput.text.Length >= 3){
            StartButton.SetActive(true);
        } else {
            StartButton.SetActive(false);
        }
    }

    public void SetUserName(){
        UsernameMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;
        //Ele irá mostrar o menu de join e create por meio do unity, mas ele não irá verificar a validade do usuário ou se deu certo, é apenas um evento onclick que faz aparecer o menu.
    }

    public void CreateGame(){
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions(){
            maxPlayers = 2
        }, null);
    }

    public void JoinGame(){
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions, TypedLobby.Default);
    }

    private void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("JogoFase1");
    }


//Fim da "public class MenuController : MonoBehaviour"
}
