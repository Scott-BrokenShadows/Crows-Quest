using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject endPanel;
    public TextMeshProUGUI coinAmount;
    public TextMeshProUGUI keyAmount;
    public TextMeshProUGUI endText;

    private void Start()
    {
        endPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Potion")
        {
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame() {
        endPanel.SetActive(true);
        endText.text = "You did it! You found " + coinAmount.text + "/20 coins and " + keyAmount.text + "/5 keys!";

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

}
