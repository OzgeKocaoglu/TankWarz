using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class ConnectionController : MonoBehaviourPunCallbacks
{


    private void Start()
    {
        Debug.Log("Connecting to server: ");
        PhotonNetwork.SendRate = 40; //20
        PhotonNetwork.SerializationRate = 5; //10
        PhotonNetwork.AutomaticallySyncScene = true; //Connection'ı kaybetmemek için sahne değişimlerinde izin verdik.
        //PhotonNetwork.NickName = MasterManager.PlayerSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server for reason: " + cause);
    }
}
