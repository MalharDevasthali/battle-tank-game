using System;
using UnityEngine;
using TankServices;
using BulletSO;

namespace TankSO
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/NewTankScriptableObject")]
    public class TankScriptableObject : ScriptableObject
    {
        [Header("Tank Type Specific")]
        public TankType tankType;

        [Header("MVC Essentials")]
        public TankView tankView;

        [Header("Health Vars")]
        public float health;

        [Header("Movement Vars")]
        public float movementSpeed;
        public float rotationSpeed;

        [Header("Shooting Vars")]
        public float fireRate;
        public BulletScriptableObject bulletType;

    }

    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/TankScriptableObjectList")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] tanks;
        public Material blueMat;
        public Material greenMat;
        public Material redMat;
    }
}