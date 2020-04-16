using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using BulletServices;
using TankSO;


namespace TankServices
{
    public class TankService : GenericSingleton<TankService>
    {
        public TankScriptableObjectList tankTypes;
        public TankScriptableObject tankScriptable { get; private set; }

        private void Start()
        {
            CreateTank(); // if you want multiple players call CreateTanks() method mutltiple times

            //tankModel do not have Mono as parent so we have to pass it using contructor's returned object
            //as view has Mono as Parent we can drag drop it via inspector
        }
        public void CreateTank()
        {
            int rand = Random.Range(0, tankTypes.tanks.Length);
            tankScriptable = tankTypes.tanks[rand];

            TankModel tankModel = new TankModel(tankScriptable, tankTypes);
            TankController controller = new TankController(tankModel, tankScriptable.tankView);
        }
    }
}