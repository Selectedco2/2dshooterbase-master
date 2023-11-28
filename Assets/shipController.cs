using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour

{
    [SerializeField]
    float speed = 5.5f;

    [SerializeField]
    GameObject boltPrefab;

    [SerializeField]
    GameObject gun;
    
    [SerializeField]
    float timeBetweenShots = 0.5f;
    float timeSinceLastShot = 0;
   
   [SerializeField]
    GameObject explosion2;
    // Update is called once per frame
    void Update()
    // kod till styrning
    {
        
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movementX = new Vector2(moveX, 0);
        Vector2 movementY = new Vector2(0, moveY);

        Vector2 movement = movementX + movementY;

        transform.Translate(movement * speed * Time.deltaTime);
        
        if (Mathf.Abs(transform.position.x) > 9.7f)
        {
            transform.Translate(-movementX * speed * Time.deltaTime);
        }
        
        if (Mathf.Abs(transform.position.y) > 4f)
        {
            transform.Translate(-movementY * speed * Time.deltaTime);
        }
        
        // Skjut kod under
        
        timeSinceLastShot += Time.deltaTime;


        if (Input.GetAxisRaw("Fire1") > 0 && timeSinceLastShot > timeBetweenShots)
        {
            Instantiate(boltPrefab, gun.transform.position, Quaternion.identity);
            timeSinceLastShot = 0;
        }


            
        
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
           Destroy(this.gameObject);    
           Instantiate(explosion2, transform.position, Quaternion.identity);
           Debug.Log("Game Over");

        }
    }
}