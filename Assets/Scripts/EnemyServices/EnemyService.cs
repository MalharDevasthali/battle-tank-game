using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Commons;
using EnemySO;
using System;
using System.Threading.Tasks;

namespace EnemyServices
{
    public class EnemyService : GenericMonoSingleton<EnemyService>
    {
        public EnemySOList enemyTypes;
        [HideInInspector] public EnemyScriptableObject enemy;
        public List<EnemyController> enemies = new List<EnemyController>();
        private Coroutine respawn;
        private EnemyController enemyController;

        private async void Start()
        {
            await new WaitForSeconds(1f);
            CreateEnemy();

        }

        private void CreateEnemy()
        {

            enemy = enemyTypes.enemies[0];

            EnemyModel enemyModel = new EnemyModel(enemy);
            enemyController = new EnemyController(enemy.enemyView, enemyModel);

            enemies.Add(enemyController);
        }
        public EnemyController GetEnemyController()
        {
            return enemyController;
        }

        public void DestroyEnemy(EnemyController enemy)
        {
            enemy.DestoryController();

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemy == enemies[i])
                {
                    enemies[i] = null;
                    enemies.Remove(enemies[i]);
                }
            }
            respawn = StartCoroutine(RespawnEnemy());

        }

        private IEnumerator RespawnEnemy()
        {
            yield return new WaitForSeconds(4f);
            CreateEnemy();
            if (respawn != null)
            {
                StopCoroutine(respawn);
                respawn = null;
            }
        }
        public void TurnOFFEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].view.gameObject.SetActive(false);
                }
            }
        }
        public void TurnONEnmeis()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].view.gameObject.SetActive(true);
                }
            }
        }
    }
}