using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject ObjectLeft; //Object which is coming from
    [SerializeField]
    private GameObject _exploEffect;
    private void Start()
    {
        Destroy(this.gameObject, 10);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(ObjectLeft != collision.gameObject)
            {
                collision.gameObject.GetComponent<PlayerHealth>().GetDamage();
                Destroy(this.gameObject);
               GameObject _expoEffect = Instantiate(_exploEffect);
                _expoEffect.transform.position = new Vector3(collision.gameObject.transform.position.x + 1, collision.gameObject.transform.position.y, 0);
                Destroy(_expoEffect.gameObject,2);

            }
        }
        else if(collision.tag == "Block")
        {
            Destroy(this.gameObject);
        }
        
    }
}
