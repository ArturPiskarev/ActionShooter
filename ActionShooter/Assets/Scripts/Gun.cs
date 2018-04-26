using Shooter;
using UnityEngine;

public class Gun : Weapons
{
    [SerializeField] private bool _isActiveStart;
    public override void Fire(Ammunition amun)
    {
        if(_fire) 
        if (amun)
        {
            Ammunition tempAmmunition = Instantiate(amun, _barrel.position, _barrel.rotation) as Bullet;
            if (tempAmmunition)
            {
                tempAmmunition.GetRigidbody.AddForce(_barrel.forward*_force);
                tempAmmunition.Name = "Bullet";
                _fire = false;
                _timer.Start(_rechargeTime);
            }
        }
    }

    private void Start ()
    {
        if (!_isActiveStart)
        {
            IsVisible = false;
        }
    }
	
	
	
}
