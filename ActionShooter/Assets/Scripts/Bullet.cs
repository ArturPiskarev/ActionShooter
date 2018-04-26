using UnityEngine;
using Shooter.Interface;
namespace Shooter
{
    public class Bullet : Ammunition
    {

        [SerializeField] private float _timeToDestruct = 10f;
        [SerializeField] private float _damage = 20f;
        [SerializeField] private float _mass = 0.02f;

        private float _currentDamge;
        private void Start()
        {
            Destroy(GetGameObject, _timeToDestruct);
            _currentDamge = _damage;
            GetRigidbody.mass = _mass;
        }

        private void OnCollisionEnter(Collision col)
        {
            SetDamage(col.gameObject.GetComponent<ISetDamage>());
            Destroy(GetGameObject);
        }

        private void SetDamage(ISetDamage obj)
        {
            if (obj != null)
            {
                obj.ApplyDamage(_currentDamge);
            }
        }
       
    }
}
