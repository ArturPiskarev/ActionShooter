using UnityEngine;

namespace Shooter.Controller
{
    public abstract class BaseController : MonoBehaviour
    {
        private bool _isEnable;

        public bool IsEnable
        {
            get { return _isEnable; }
            set { _isEnable = value; }
        }

        public virtual void On()
        {
            IsEnable = true;
        }

        public virtual void Off()
        {
            IsEnable = false;
        }
    }
}