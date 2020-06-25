using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    private MultiplayerCanvases _multiplayerCanvases;

    public void FirstInitialize(MultiplayerCanvases _canvases)
    {
        _multiplayerCanvases = _canvases;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
