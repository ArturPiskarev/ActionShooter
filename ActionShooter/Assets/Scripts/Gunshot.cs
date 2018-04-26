using Shooter;

public class Gunshot : Weapons {

	
	private void Start () {
        IsVisible = false;
    }
	

    public override void Fire(Ammunition amun)
    {
        if (_fire)
            if (amun)
            {
                Ammunition tempAmmunition = Instantiate(amun, _barrel.position, _barrel.rotation) as BulletShot;
                if (tempAmmunition)
                {
                    tempAmmunition.GetRigidbody.AddForce(_barrel.forward * _force);
                    tempAmmunition.Name = "BulletShot";
                    _fire = false;
                    _timer.Start(_rechargeTime);
                }
            }
    }
}
