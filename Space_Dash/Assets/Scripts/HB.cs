using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HB : MonoBehaviour
{
  public Slider healthSlider;
  public Slider otherSlider;
  public float maxHealth = 200f;
  public float Health;
  public float LerpSpeed = 0.05f;

  void Start()
  {
    Health = maxHealth; //Make Health equal to MaxHealth at the start of the game.
  }

  void Update()
  {
    if(healthSlider.value != Health) //If  the value of the slider is not equal to the Health.
    {
      healthSlider.value = Health; //Then make it equal.
    }
  }
}
