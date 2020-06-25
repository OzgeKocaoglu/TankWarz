using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedTankUI : MonoBehaviour
{
    public TankSelectionScroolBar _scroolbar;
    public Character[] characters;
    public Image _body;
    public Image head;


    public void OnClick_Done()
    {
       if(_scroolbar.GetSelected().y == 95)
        {
            _body.sprite = characters[0]._body;
            head.sprite = characters[0]._head;
            characters[0]._ISSELECTED = true;
            Debug.Log(characters[0].name);
        }
       else if(_scroolbar.GetSelected().y == 10)
        {
            _body.sprite = characters[1]._body;
            head.sprite = characters[1]._head;
            characters[1]._ISSELECTED = true;
            Debug.Log(characters[1].name);
        }
       else if(_scroolbar.GetSelected().y == -75)
        {
            _body.sprite = characters[2]._body;
            head.sprite = characters[2]._head;
            characters[2]._ISSELECTED = true;
            Debug.Log(characters[2].name);
        }
    }


}
