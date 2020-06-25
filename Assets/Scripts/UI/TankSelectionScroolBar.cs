using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankSelectionScroolBar : MonoBehaviour
{
    public RectTransform _transform;
    public RectTransform _firstTransform;
   
    private void Awake()
    {
        _transform = this.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if(_transform.localPosition.y >= -75)
        {
           // Debug.Log("İlk pozisyon: " + _transform.localPosition.y);
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                _transform.localPosition += new Vector3(0, -85, 0);
                Debug.Log(_transform.localPosition.y);
            }
        }
        else
        {
            _transform.localPosition = new Vector3(_transform.localPosition.x, 95);
        }
        
    }

    public Vector3 GetSelected()
    {
        return _transform.localPosition;
    }
}
