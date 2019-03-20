using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    // TODO: Work on the HUD and do the operations.
    [SerializeField]
    private int initialEnergy = 3;
    private int currentEnergy;

    void Awake()
    {
        currentEnergy = initialEnergy;
    }

    /// <summary>
    /// Verify if the player has energy to perform a hit.
    /// </summary>
    /// <param name="energyRequired">Integer based on hit cost</param>
    /// <returns>Returns true, false otherwise.</returns>
    public bool CanCast(int energyRequired)
    {
        if (currentEnergy >= energyRequired)
        {
            return true;
        }
        else
            return false;
    }

    /// <summary>
    /// Adds energy to a players pool.
    /// </summary>
    /// <param name="amount">The amount of energy to be add.</param>
    public void addEnergy(int amount)
    {
        if(currentEnergy+amount > initialEnergy)
        {   currentEnergy = initialEnergy; }
        else
        {   currentEnergy += amount; }
    }

    /// <summary>
    /// Consume energy from a player.
    /// </summary>
    /// <param name="energyRequired">The amount of energy to consume.</param>
    public void consumeEnergy(int energyRequired)
    {
        currentEnergy -= energyRequired;
    }
}
