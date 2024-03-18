using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSelfCon : MonoBehaviour
{
  public float bulletSpeed = 10f;
  private Vector3 targetPosition;
  private float DestroyBulletTime;

  void Start()
  {
    
    targetPosition = transform.position; //Set the direction of the bullet.

    
    MoveToMouseClick(); //Call MoveToMouseClick function.

    DestroyBulletTime = Time.time; //Destroy the bullet if there is 5 seconds.
  }

  void MoveToMouseClick()
  {
    
    if (Input.GetMouseButtonDown(0)) //Check if the player is clicking ot not.
    {
      targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get mouse position when clicked.
      targetPosition.z = 0f; //And make it as a z axis.
    }

    Vector2 direction = (targetPosition - transform.position).normalized; //Make the bullet face towards where it's going.

    
    GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed; //Adjust the bullet's speed.
  }

  void Update()
  {

    if (Time.time - DestroyBulletTime >= 5.0f) //Make a condition if the bullet is active for 5 seconds, do this.
    {
      Destroy(gameObject); //Destroy the bullet.
    }
  }
}
