using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCollisionScript : MonoBehaviour
{
    bool inBodyPart = false;
    public Sprite BodyPartCut;
    public GameObject managerObject;
    public GameObject chargeBar;
    public AudioClip cutClip;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            CutBodyPart();
        }
        
    }

    private void CutBodyPart()
    {
        if (inBodyPart == true)
        {
            if (chargeBar.GetComponent<ChargeBar>().chargeBarAmount >= 100f)
            {
                if (gameObject.GetComponent<SpriteRenderer>().sprite != BodyPartCut)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = BodyPartCut;
                    managerObject.GetComponent<IntManager>().cutInt++;
                    AxeCuttingAudioManager.current.PlaySound(cutClip);
                    StartCoroutine(AnimatePart());
                }
            }
        }
    }

    IEnumerator AnimatePart()
    {
        float currentTime = Time.time;
        float randomXDir = Random.Range(0, 10);
        float randomYDir = Random.Range(0, 10);

        while (Time.time < currentTime + 3f)
        {
            transform.Rotate(0, 0, 4f);
            transform.position += new Vector3(randomXDir * 3f * Time.deltaTime, randomYDir * 3f * Time.deltaTime);
            yield return null;
        }
    }

    void OnMouseEnter()
    {
        inBodyPart = true;
    }

    void OnMouseExit()
    {
        inBodyPart = false;
    }
}
