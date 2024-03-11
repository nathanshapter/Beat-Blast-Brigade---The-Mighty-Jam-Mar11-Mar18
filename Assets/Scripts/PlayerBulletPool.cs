using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour
{
   public static PlayerBulletPool Instance;

    public GameObject bulletPrefab;
    public int poolSize = 20;

    public GameObject playerGun;

   public List<GameObject> playerBulletPool;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            playerBulletPool.Add(bullet);
        }
    }

   public GameObject GetBulletPrefab()
    {
        foreach (GameObject bullet in playerBulletPool) 
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                bullet.transform.position = playerGun.transform.position;
                return bullet;
            }
        }
        // if no active bullets are found expand the pool

        GameObject newBullet = Instantiate(bulletPrefab);
        playerBulletPool.Add(newBullet);
        return newBullet;
    }
    public void ReturnBullet(GameObject bullet)
    {
        bullet.GetComponent<PlayerBullet>().timer = 3;
        bullet.SetActive(false);
    }
}
