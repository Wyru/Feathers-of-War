using UnityEngine;
using UnityEngine.Events;
using GameLogicV2;

namespace GameLogicV2
{
    public class GameLoop : MonoBehaviour
    {

        [Header("Turn Setup")]
        [SerializeField] float startTurnDuration;
        [SerializeField] float minTurnDuration;
        [SerializeField] float turnTimeDrop;

        [Header("Players Controller")]
        public GameObject playerOne;
        public GameObject playerTwo;


        PlayerController playerOneController;
        PlayerStatus playerOneStatus;
        PlayerController playerTwoController;
        PlayerStatus playerTwoStatus;


        float turnDuration;
        float cTime;

        public enum GameStates
        {
            Intro,
            ChoosingAction,
            ExecutingAction,
            Comeback,
            End
        }

        GameStates state;

        private void Start()
        {
            turnDuration = startTurnDuration;
            state = GameStates.Intro;

            playerOneController = playerOne.GetComponent<PlayerController>();
            playerTwoController = playerTwo.GetComponent<PlayerController>();

            playerOneStatus = playerOne.GetComponent<PlayerStatus>();
            playerTwoStatus = playerTwo.GetComponent<PlayerStatus>();

        }

        public bool runnigIntro;
        public bool gameEnded;

        private void Update()
        {

            switch (state)
            {
                case GameStates.Intro:
                    UpdateIntro();
                    break;

                case GameStates.ChoosingAction:
                    UpdateTurn();
                    break;

                case GameStates.ExecutingAction:
                    UpdateExecutingAction();
                    break;

                case GameStates.Comeback:
                    UpdateComeback();
                    break;

                case GameStates.End:
                    UpdateEnd();
                    break;
            }
        }

        void UpdateIntro()
        {
            if(!runnigIntro){
                turnStart();
            }
        }

        void UpdateTurn()
        {
            cTime -= Time.deltaTime;
            
            if(cTime <= 0){
                turnEnd();
                return;
            }

            playerOneController.ManageInput();
            playerTwoController.ManageInput();
        }

        void turnStart()
        {
            cTime = turnDuration;
            state = GameStates.ChoosingAction;
        }

        void turnEnd()
        {
            turnDuration = Mathf.Max(minTurnDuration, turnDuration - turnTimeDrop);
            state = GameStates.ExecutingAction;
        }

        void UpdateExecutingAction(){
            playerOneController.DoAction();
            playerTwoController.DoAction();

            // Comeback or Game Over
            if(!playerOneStatus.IsAlive() || !playerTwoStatus.IsAlive()){
                state = GameStates.Comeback;
                return;
            }

            if(playerOneController.ActionAnimationEnded() && playerTwoController.ActionAnimationEnded()){
                turnStart();
            }
            
        }

        void UpdateComeback(){
            //
        }

        void UpdateEnd(){
            
        }

    }
}
