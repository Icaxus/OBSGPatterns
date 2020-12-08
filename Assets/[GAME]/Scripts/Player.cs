using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody { get { return (_rigidbody == null) ? _rigidbody = GetComponent<Rigidbody>() : _rigidbody; } }

    [SerializeField]
    private int _moveSpeed = 0;

    /* ÜST SATIRIN AÇILMIŞ HALİ */
    //public Rigidbody Rigidbody
    //{
    //    get
    //    {
    //        if (_rigidbody == null)
    //        {
    //            _rigidbody = GetComponent<Rigidbody>();
    //        }
    //        return _rigidbody;
    //    }
    //}
    /* ÜST SATIRIN AÇILMIŞ HALİ */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 newMove = input * _moveSpeed * Time.fixedDeltaTime;
        newMove.y = Rigidbody.velocity.y;
        Rigidbody.velocity = newMove;
        //Rigidbody.AddForce(newMove,ForceMode.Impulse);

    }
    public int point = 0; //Bu değeri tanımlamanın daha optimize yolları vardır.

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.gameObject.GetComponent<Coin>(); //other.GetComponent<Coin>()

        if(coin != null)
        {
            point++; // player += 1 | player = player + 1 | point -= -1;
            coin.PickUpCoin(point);
        }
        
    }

}
