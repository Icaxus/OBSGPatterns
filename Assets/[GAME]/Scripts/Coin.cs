using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CoinManager.Instance.AddCoin(this);
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        CoinManager.Instance.RemoveCoin(this);
    }

    public void PickUpCoin(int point)
    {
        EventManager.OnCoinPickUp.Invoke();
        Destroy(gameObject); // this script'i yok eder |  gameObject = this.gameObject
    }
}
