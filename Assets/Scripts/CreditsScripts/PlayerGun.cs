using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EndSceneGEM.current.onTextShot += NormalShot;
        EndSceneGEM.current.onInvulnerableTextShot += InvulnerableShot;
    }

    private void NormalShot()
    {
    }

    private void InvulnerableShot()
    {

    }
}
