using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace EnemyServices
{
    public class EnemyStates : MonoBehaviour
    {
        //  private EnemyStates currentState;

        //if I use private variable for EnemyStates ChangeState method takes currentState as null..?? why?? 
        //if i use EnemyStates ref. from EnemyVIew it works fine??? 
        // inheretance is turining out hell to me...:(

        public EnemyView enemyView;



        protected virtual void Awake()
        {
            //enemyView = GetComponent<EnemyView>();

            //not woking..null ref. exeception for enemyView in childClasses??? 
        }


        protected virtual void Start()
        {
            InitializeState();
        }


        public virtual void OnStateEnter()
        {
            this.enabled = true;
        }
        public virtual void OnStateExit()
        {
            this.enabled = false;
        }
        private void InitializeState()
        {
            switch (enemyView.initialState)
            {
                case EnemyState.Attacking:
                    enemyView.currentState = enemyView.attackingState;
                    break;
                case EnemyState.Chasing:
                    enemyView.currentState = enemyView.chasingState;
                    break;
                case EnemyState.Patrolling:
                    enemyView.currentState = enemyView.patrollingState;
                    break;
                default:
                    enemyView.currentState = null;
                    break;
            }
            enemyView.currentState.OnStateEnter();
        }

        public void ChangeState(EnemyStates newState)
        {
            if (enemyView.currentState != null)
                enemyView.currentState.OnStateExit();

            enemyView.currentState = newState;
            enemyView.currentState.OnStateEnter();
        }
    }
}
