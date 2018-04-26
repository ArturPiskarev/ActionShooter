using UnityEngine;

namespace Shooter.Controller
{
    public sealed class WeaponController : BaseController
    {
        private Weapons _weapons;
        private Ammunition _ammunition;
        private int _mouseButton = (int)Main.MyEnum.LeftButton;

        public Weapons GetSelectedWeapons
        {
            get { return _weapons; }
        }

        private void Update()
        {
            if(!IsEnable)return;
            if (Input.GetMouseButton(_mouseButton))
            {
                if (_weapons)
                {
                    GetSelectedWeapons.Fire(_ammunition);
                }
            }
        }

        public void On(Weapons weapons, Ammunition ammunition)
        {

            if (IsEnable) return;
            _weapons = weapons;
            _ammunition = ammunition;
            _weapons.IsVisible = true;
            base.On();
        }

        public override void Off()
        {
           
            if (!IsEnable) return; 
            _weapons.IsVisible = false;
            _weapons = null;
          _ammunition = null;
            base.Off();
        }
    }
}
