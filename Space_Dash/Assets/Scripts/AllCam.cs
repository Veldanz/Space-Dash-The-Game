using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCam : MonoBehaviour
{
  public Transform player;
  public float smoothSpeed = 0.125f;
  public Vector3 offset;

  void Start()
  {
    transform.position = player.position + offset; //Transform the camera position to the player position.
  }

  void Update()
  {
    Vector3 targetPosition = player.position + offset; //Transform along the player.

    transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime); //make the transform more slow.
  }
}
