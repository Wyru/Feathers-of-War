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
    private AudioClip[] damageClips = null;

    [SerializeField]
    private bool isDead = false;

    void Awake()
    {
        healthSlider = GetComponent<Slider>();

        currentHealth = initialHealth;
    }

    /// <summary>
    /// Performe the damage Operations.
    /// </summary>
    /// <param name="amount">The amount of damage inflicted to a player.</param>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        healthSlider.value = currentHealth;

        int i = Random.Range(0, damageClips.Length);
        AudioSource.PlayClipAtPoint(damageClips[i], transform.position);

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
