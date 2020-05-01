using System.Collections;
using System.Collections.Generic;
using TankServices;
using UnityEngine;

namespace EnemyServices
{
    public class EnemyChasingState : EnemyStates
    {
        protected override void Awake()
        {
        }
        protected override void Start()
        {
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            Debug.Log("Entering Chase");
            enemyView.activeState = EnemyState.Chasing;
            enemyView.controller.Chase();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Debug.Log("Exiting Chase");
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                enemyView.SetTankView(other.gameObject.GetComponent<TankView>());
                ChangeState(this);
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (enemyView.activeState == EnemyState.Attacking) return;

            if (other.gameObject.GetComponent<TankView>() != null)
            {
                enemyView.SetTankView(other.gameObject.GetComponent<TankView>());
                enemyView.controller.Chase();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                ChangeState(enemyView.patrollingState);
            }
        }
    }
}