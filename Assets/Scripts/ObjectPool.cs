using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    private int sizeBullets = 20;
    private List<GameObject> bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new List<GameObject>();

        for (int i = 0; i < sizeBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.parent = transform;
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }

    }

    public GameObject GetBullet()
    {
        for(int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                bulletPool[i].SetActive(true);
                return bulletPool[i];
            }
        }

        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(false);
        newBullet.transform.parent = transform;
        bulletPool.Add(newBullet);
        return newBullet;
    }

}
