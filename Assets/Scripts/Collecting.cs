using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collecting : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public TextMeshProUGUI keys;

    int coinsCollected = 0;
    int keysCollected = 0;
    string coinsCounter;
    string keysCounter;

    // Start is called before the first frame update
    void Start()
    {
        coins.text = "0";
        keys.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCoin()
    {
        coinsCollected++;
        coinsCounter = coinsCollected.ToString();
        coins.text = coinsCounter;
    }

    public void GetKey()
    {
        keysCollected++;
        keysCounter = keysCollected.ToString();
        keys.text = keysCounter;
    }
}
