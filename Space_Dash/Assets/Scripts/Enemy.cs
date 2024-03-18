using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float moveSpeed = 2.0f;
  public Transform player;
  public GameObject bulletPrefab;
  public float fireRate = 0.5f;

  private float nextFireTime;

  void Start()
  {
    nextFireTime = Time.time + fireRate; //Make the fire rate as a time variable so it can be changed in the inspect.
  }

  void Update()
  {
    Vector3 targetPosition = player.position; //Make the player position be a target position.

    transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); //Transform enemy position to player position.

    if (Time.time >= nextFireTime) //If time it's time to fire, create a bullet and update the next fire time.
    {
      ShootBullet(); //Call the ShootBullet function.
      nextFireTime = Time.time + fireRate;
    }
  }

  void ShootBullet() //Create ShootBullet function.
  {
    Instantiate(bulletPrefab, transform.position, Quaternion.identity); //Use the bullet's prefab and spawn them.
  }
}
