using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotBreaker : MonoBehaviour
{
    public GameObject brokenPot;
    public GameObject coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lantern")
        {
            Instantiate(brokenPot, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            Instantiate(coin, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 2, this.gameObject.transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
