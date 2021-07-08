using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private Vector3 originalPosition;

    void MoveToHide(GameObject playerObject)
    {
        playerObject.GetComponent<PlayerController>().Stop();
        originalPosition = playerObject.transform.position;
        playerObject.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y + 1.5f, 0);
    }

    void MoveToPath(GameObject playerObject)
    {
        playerObject.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y - 1.5f, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            print("Hiding");
            MoveToHide(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        MoveToPath(other.gameObject);
        other.transform.parent = null;
    }
}
