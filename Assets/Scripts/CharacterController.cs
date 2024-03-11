using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D rb;
    [SerializeField] float runSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        Run();  
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
      
    }

    void Run()
    {
        if (rb != null)
        {
           
            rb.velocity = moveInput * runSpeed;
        }
    }

    void OnFire(InputValue value)
    {
        
        PlayerBulletPool.Instance.GetBulletPrefab();
    }
}
