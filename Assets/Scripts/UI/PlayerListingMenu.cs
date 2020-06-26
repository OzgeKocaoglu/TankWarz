using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _playerListPrefab;
    private MultiplayerCanvases _canvases;

    private List<PlayerListing> _listing = new List<PlayerListing>();


    public override void OnEnable()
    {
        base.OnEnable();
        GetCurrentRoomPlayers();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for(int i = 0; i < _listing.Count; i++)
        {
            Destroy(_listing[i].gameObject);
        }
        _listing.Clear();
    }

    public void FirstInitialize(MultiplayerCanvases canvases)
    {
        _canvases = canvases;
    }

    private void GetCurrentRoomPlayers()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;
        foreach(KeyValuePair<int, Player> playerinfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerinfo.Value);
        }
        
    }

    private void AddPlayerListing(Player player)
    {
        int index = _listing.FindIndex(x => x.Player == player);
        if(index != -1)
        {
            _listing[index].SetPlayerInfo(player);
        }
        else
        {
            PlayerListing listing = (PlayerListing)Instantiate(_playerListPrefab, _content);
            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                _listing.Add(listing);
            }
        }
       
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _listing.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(_listing[index].gameObject);
            _listing.RemoveAt(index);
        }
    }

    public void OnClick_StartGame()
    {
        PhotonNetwork.LoadLevel(2);
    }
}
