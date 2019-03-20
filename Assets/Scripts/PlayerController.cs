using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private static string playerNumber = "1";
    private string chargeAttackButton;
    private string attackButton;
    private string defenceButton;
    private string evadeButton;

    void Awake()
    {
        chargeAttackButton = String.Concat("ChargeAttack_P", playerNumber);
        attackButton = String.Concat("Attack_P", playerNumber);
        defenceButton = String.Concat("Defense_P", playerNumber);
        evadeButton = String.Concat("Evade_P", playerNumber);
    }
    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        // Treat input
        if (Input.GetButtonDown(chargeAttackButton))
        { }
        if (Input.GetButtonDown(attackButton))
        { }
        if (Input.GetButtonDown(defenceButton))
        { }
        if (Input.GetButtonDown(evadeButton))
        { }
    }
}
