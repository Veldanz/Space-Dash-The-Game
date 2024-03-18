using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 15f;
    public float dashDuration = 0.5f; 
    private Rigidbody2D rb;
    private bool isDashing = false;

    public GameObject bulletPrefab;

    public int PlayerHP = 100;
    public Text showHP;


    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); //Get input from the player for moving left and right.
        float moveY = Input.GetAxis("Vertical"); //Get input from the player for jumping upwards.
        showHP.text = PlayerHP.ToString(); //Convert integer HP to string so it can be displayed on screen.

        
        Vector2 movement = new Vector2(moveX, moveY);
        movement.Normalize(); 
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing) //If player press space bar and is not dashing, do this.
        {
            StartCoroutine(Dash(movement)); //Dash
        }
        if (Input.GetMouseButtonDown(0)) //If player is clicking mouse, do this.
        {
            SpawnBullet(); //Shoot by spawn function.
        }

        if(PlayerHP <= 0) //If playerHP is less than 0 or equal to 0, do this.
        {
           
            Destroy(gameObject); //Destroy game object.
            SceneManager.LoadScene("Lost"); //Load scene name "Lost".        
        }
    }

    IEnumerator Dash(Vector2 direction) //Create Dash function.
    {
        isDashing = true; //If player is dashing.

        
        GetComponent<Collider2D>().enabled = false; //Set collider to false.

        
        rb.AddForce(direction * dashSpeed, ForceMode2D.Impulse); //Dash speed.

        
        tr.emitting = true; 
        yield return new WaitForSeconds(dashDuration); 
        tr.emitting = false;
        
        GetComponent<Collider2D>().enabled = true;

        
        rb.velocity = Vector2.zero;

        
        isDashing = false;
    }

     void SpawnBullet()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity); //Spawn the bullet prefabs.

    }

    void OnTriggerEnter2D(Collider2D other) //Check the collision.
    {
        
        if (other.CompareTag("EnemyBullet")) //If player hits enemy's bullet, do this.
        {
            PlayerHP -= 5; //Decrease PlayerHP by 5.
        }
    }


}