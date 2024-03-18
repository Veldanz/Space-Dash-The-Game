using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
     public string playerTag = "Player";
     public float moveSpeed = 2.0f;

     private Transform player;
    
     private float DestroyBulletTime;

     void Start()
     {
      player = GameObject.FindGameObjectWithTag(playerTag).transform; //Find game object with playerTag.

      DestroyBulletTime = Time.time; //Set DestroyBulletTime the same as Time.
    
     }

     void Update()
     {
      if (player == null)  return; //If there is no player, exit
      {
       return;
      }

      Vector3 targetPosition = player.position; //Make destination to player position.

      transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); //Make bullet move to the player.

      Vector3 direction = player.position - transform.position;  //Direction from bullet to player.
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
      transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

      if (Time.time - DestroyBulletTime >= 5.0f) //If the bullet is active for 5 seconds, do this.
      {
       Destroy(gameObject); //Destroy game object.
      }
     }

     public void SetMoveSpeed(float newSpeed) //Set the bullet speed.
     {
      moveSpeed = newSpeed;
    }
}
