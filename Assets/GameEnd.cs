using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject endPanel;

    private void Start()
    {
        endPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Potion")
        {
            endPanel.SetActive(true);
        }
    }
}
