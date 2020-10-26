
using UnityEngine;

namespace BulletSO
{
    [CreateAssetMenu(fileName = "BulletSOList", menuName = "ScriptableObject/Bullet/NewBulletScriptableObjectList")]
    public class BulletSOList : ScriptableObject
    {
        public BulletScriptableObject[] bulletsTypes;

    }
}