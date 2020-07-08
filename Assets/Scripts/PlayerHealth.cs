using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon;
using Photon.Realtime;

public class PlayerHealth : MonoBehaviourPunCallbacks
{
    public int Health = 100;
    public PhotonPlayerCreator _playerCreator;

    private void Start()
    {
        if (photonView.IsMine)
        {

        }
        else
        {
            GetComponent<PlayerMovement>().enabled = false;
        }

        _playerCreator = GameObject.Find("MultiplayerManager").GetComponent<PhotonPlayerCreator>();
    }

    public void GetDamage()
    {
        Health -= Random.Range(15,30);
        Death();
    }

    public void Death()
    {
        if(Health <= 0 && photonView.IsMine)
        {
            _playerCreator.ReSpawn();
            Debug.Log("One player is death");
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
