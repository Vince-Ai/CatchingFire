using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 100;
    public float currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 0.1f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

   // AudioSource playerAudio;
   // PlayerMovement playerMovement;
	TheEventManager theEventManager;
    public bool damaged;

    void Awake ()
    {
  //      playerAudio = GetComponent <AudioSource> ();
   //     playerMovement = GetComponent <PlayerMovement> ();
        currentHealth = startingHealth;
		theEventManager = GetComponent<TheEventManager> ();
		damageImage.color = Color.clear;
    }


    void Update ()
    {
		
        if(damaged)
        {
            damageImage.color = flashColour;
			TakeDamage ();
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage ()
    {
        damaged = true;

		currentHealth -= 50f*Time.deltaTime;

        healthSlider.value = currentHealth;

		if(currentHealth <= 0 && !theEventManager.isOver)
        {
			theEventManager.isOver = true;
        }
    }		
}
