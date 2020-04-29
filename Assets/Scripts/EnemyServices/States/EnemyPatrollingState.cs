﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyServices
{
    public class EnemyPatrollingState : EnemyStates
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
            Debug.Log("Entering Patrol");
            enemyView.activeState = EnemyState.Patrolling;
        }
        private void Update()
        {
            enemyView.controller.Patrol();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Debug.Log("Exiting Patrol");

        }
    }
}
