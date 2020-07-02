using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView _photonView;
    public GameObject _myTank;

    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, GameManager._gameManager.spawnPoints.Length);
        if (_photonView.IsMine)
        {
            _myTank = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs" , "TankPlayer"), GameManager._gameManager.spawnPoints[spawnPicker].position, GameManager._gameManager.spawnPoints[spawnPicker].rotation, 0);
        }
    }
}
