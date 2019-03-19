using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int initialHealth = 100;
    private int currentHealth;
    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    AudioSource playerAudio;
    private bool isDead = false;

    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        healthSlider = GetComponent<Slider>();

        currentHealth = initialHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play();

        if (currentHealth <= 0 && !isDead) { Comeback(); }
    }

    void Comeback()
    {
        // TODO: Comeback Feature
    }

    void Death()
    {
        // TODO: Death Feature
    }
}
