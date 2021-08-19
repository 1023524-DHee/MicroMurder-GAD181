using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostVictim : MonoBehaviour
{
    public GameObject victim;
    public Camera camera;

    void Update()
    {
        if (victim.transform.position.x > (camera.transform.position.x + 6))
        {
            Debug.Log("Lost Victim");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
