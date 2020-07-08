using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon;
using Photon.Realtime;

public class PlayerHealth : MonoBehaviourPunCallbacks
{
    private int Health = 100;
    public PhotonPlayerCreator _playerCreator;
    private DeathCounter deathCounter;

    private void Start()
    {
        deathCounter = FindObjectOfType<DeathCounter>();
        if (photonView.IsMine)
        {

        }
        else
        {
            GetComponent<PlayerMovement>().enabled = false;
        }

        _playerCreator = GameObject.Find("MultiplayerManager").GetComponent<PhotonPlayerCreator>();
    }

    public int GetHealth()
    {
        if (photonView.IsMine)
        {
            return this.Health;
        }
        else
        {
            return 0;
        }
    }


    public void GetDamage(string shooter)
    {
        Health -= Random.Range(15,30);
        Death(shooter);
    }

    public void Death(string shooter)
    {
        if(Health <= 0 && photonView.IsMine)
        {
            deathCounter.GetComponent<PhotonView>().RPC("DeathHappen", RpcTarget.All, shooter, photonView.Owner.NickName);
            _playerCreator.ReSpawn();
            Debug.Log("One player is death");
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
