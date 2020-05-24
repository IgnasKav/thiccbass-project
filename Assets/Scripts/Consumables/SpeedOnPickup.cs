using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOnPickup : MonoBehaviour
{
    public float speedBoost = 100f;

    void Start() {
        StartCoroutine("floatAnimation");
    }
    //Paimamas consumable
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") {
            PlayerMovement playerScript = collider.gameObject.GetComponent<PlayerMovement>();
            playerScript.boosting = true;
            playerScript.runSpeed = speedBoost;
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    IEnumerator floatAnimation()
    {
        float offset = 0.15f;
        transform.parent.gameObject.transform.position += new Vector3(0, offset / 2, 0);
        yield return new WaitForSeconds(0.15f);
        transform.parent.gameObject.transform.position += new Vector3(0, offset, 0);
        yield return new WaitForSeconds(0.15f);
        transform.parent.gameObject.transform.position += new Vector3(0, -offset / 2, 0);
        yield return new WaitForSeconds(0.15f);
        transform.parent.gameObject.transform.position += new Vector3(0, -offset, 0);
        yield return new WaitForSeconds(0.15f);
        yield return StartCoroutine("floatAnimation");
    }
}