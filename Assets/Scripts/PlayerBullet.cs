using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 10f;

   public float timer = 3;



    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            PlayerBulletPool.Instance.ReturnBullet(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerBulletPool.Instance.ReturnBullet(gameObject);
    }
}
