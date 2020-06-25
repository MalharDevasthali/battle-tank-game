using UnityEngine;
using Commons;
using BulletServices;
using BulletSO;
using VFXServices;
using AchievementServices;
using SFXServices;

namespace TankServices
{
    public class TankController
    {
        public TankModel tankModel { get; private set; }
        public TankView tankView { get; private set; }
        private Rigidbody rigidbody;

        public TankController(TankModel _tankModel, TankView _tankView) //constructor
        {

            tankModel = _tankModel;
            tankView = GameObject.Instantiate<TankView>(_tankView);
            CameraController.instance.SetTarget(tankView.transform);
            rigidbody = tankView.GetComponent<Rigidbody>();
            tankView.SetTankController(this);
            tankModel.SetTankController(this);
            tankView.ChangeColor(tankModel.material);
            SubscribeEvents();
            UIService.instance.UpdateHealthText(tankModel.health);
        }



        private void SubscribeEvents()
        {
            EventService.instance.OnPlayerFiredBullet += UpdateBulletsFiredCounter;
        }

        public void Move(float movement, float movementSpeed)
        {
            Vector3 move = tankView.transform.transform.position += tankView.transform.forward * movement * movementSpeed * Time.fixedDeltaTime;
            rigidbody.MovePosition(move);
        }

        public void Rotate(float rotation, float rotateSpeed)
        {
            Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
            Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
            rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
        }

        public void ShootBullet()
        {
            EventService.instance.InvokeOnPlayerFiredBulletEvent();
            BulletService.instance.CreateBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }

        private void UpdateBulletsFiredCounter()
        {
            tankModel.BulletsFired += 1;
            PlayerPrefs.SetInt("BulletsFired", tankModel.BulletsFired);
            Debug.Log(tankModel.BulletsFired);
            AchievementService.instance.GetAchievementController().CheckForBulletFiredAchievement();
        }

        public Vector3 GetFiringPosition()
        {
            return tankView.BulletShootPoint.position;
        }
        public Quaternion GetFiringAngle()
        {
            return tankView.transform.rotation;
        }
        public BulletScriptableObject GetBullet()
        {
            return tankModel.bulletType;
        }
        public Vector3 GetCurrentTankPosition()
        {
            return tankView.transform.position;
        }

        public void DestroyController()
        {
            // SFXService.instance.PlaySound()
            VFXService.instance.InstantiateEffects(tankView.TankDestroyVFX, tankView.transform.position);
            UIService.instance.ResetScore();
            tankModel.DestroyModel();
            tankView.DestroyView();
            tankModel = null;
            tankView = null;
            rigidbody = null;
            UnSubscribeEvents();
        }
        private void UnSubscribeEvents()
        {
            EventService.instance.OnPlayerFiredBullet -= UpdateBulletsFiredCounter;
        }

        private void Dead()
        {
            TankService.instance.DestroyTank(this);
        }
        public void ApplyDamage(float damage)
        {
            if (tankModel.health - damage <= 0)
                Dead();
            else
            {
                tankModel.health -= damage;
                UIService.instance.UpdateHealthText(tankModel.health);
            }
        }
    }
}