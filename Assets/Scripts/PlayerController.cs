using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string playerNumber = "1";
    private string chargeAttackButton;
    private string attackButton;
    private string defenceButton;
    private string evadeButton;


    public event Action OnAttack;
    public event Action OnDefend;
    public event Action OnEvade;
    public event Action OnCharge;

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
        {
            GameLogic.Instance.GetInput(playerNumber,"Charge");
        }
        if (Input.GetButtonDown(attackButton))
        { 
            GameLogic.Instance.GetInput(playerNumber,"Attack");
        }
        if (Input.GetButtonDown(defenceButton))
        { 
            GameLogic.Instance.GetInput(playerNumber,"Defend");
        }
        if (Input.GetButtonDown(evadeButton))
        { 
            GameLogic.Instance.GetInput(playerNumber,"Evade");
        }
    }

    public void Attack(){
        if(OnAttack != null){
            OnAttack.Invoke();
        }
    }

    public void Defend(){
        if(OnDefend != null){
            OnDefend.Invoke();
        }
    }

    public void Evade(){
        if(OnEvade != null){
            OnEvade.Invoke();
        }
    }

    public void Charge(){
        if(OnCharge != null){
            OnEvade.Invoke();
        }
    }

}
