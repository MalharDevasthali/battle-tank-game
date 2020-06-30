﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameServices;

namespace EnemyServices
{
    public class EnemyPatrollingState : EnemyStates
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            enemyView.activeState = EnemyState.Patrolling;
        }
        private void Update()
        {
            enemyView.controller.Patrol();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }
}
