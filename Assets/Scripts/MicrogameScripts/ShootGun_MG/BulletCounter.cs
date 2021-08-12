using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCounter : MonoBehaviour
{
    public List<GameObject> bulletList;

    // Start is called before the first frame update
    void Start()
    {
        ShootGunGEM.current.onVictimShotFail += DecrementBullet;
        ShootGunGEM.current.onVictimShotSuccess += DecrementBullet;
    }

    private void DecrementBullet()
    {
        if (bulletList.Count > 0)
        {
            bulletList[bulletList.Count - 1].SetActive(false);
            bulletList.RemoveAt(bulletList.Count - 1);
        }

        if (bulletList.Count == 0) ShootGunGEM.current.GameEnd();
    }
}
