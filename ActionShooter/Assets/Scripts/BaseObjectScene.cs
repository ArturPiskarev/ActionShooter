using UnityEngine;

namespace Shooter
{
    public class BaseObjectScene : MonoBehaviour
    {

        private int _layer;
        private string _name;
        private GameObject _gameObject;
        private Rigidbody _rigidbody;
        private Transform _transform;
        private Color _color;
        private Material _material;
        private Vector3 _position;
        private Quaternion _rotation;
        private bool _isVisible;

        public int Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
                AskLayer(GetTransform, _layer);
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                GetGameObject.name = _name;
            }
        }

        public GameObject GetGameObject
        {
            get { return _gameObject; }
        }

        public Rigidbody GetRigidbody
        {
            get { return _rigidbody; }
        }

        public Transform GetTransform
        {
            get { return _transform; }
        }

        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                if (_material != null)
                {
                    _material.color = _color;
                }
                AskColor(GetTransform, _color);
            }
        }

        public Material GetMaterial
        {
            get { return _material; }
        }

        public Vector3 Position
        {
            get
            {
                if (GetGameObject != null)
                {
                    _position = GetTransform.position;
                }
                return _position;
            }
            set
            {
                _position = value;
                if (GetGameObject != null)
                {
                    GetTransform.position = _position;
                }
            }
        }

        public Quaternion Rotation
        {
            get
            {
                if(GetGameObject!=null)
                {
                    _rotation = GetTransform.rotation;
                }
                return _rotation;
            }
            set
            {
                _rotation = value;
                if (GetGameObject != null)
                {
                    GetTransform.rotation = _rotation;
                }
            }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
               // if (GetGameObject.activeSelf) 
                GetGameObject.SetActive(_isVisible);
                //if (_gameObject.GetComponent<SkinnedMeshRenderer>())
                  //  _gameObject.GetComponent<SkinnedMeshRenderer>().enabled = _isVisible;
                //
            }
        }

        private void AskColor(Transform obj, Color color)
        {
            if(obj.gameObject.GetComponent<Renderer>().material!=null)
            obj.gameObject.GetComponent<Renderer>().material.color = color;
            
            if (obj.childCount > 0)
            {
                foreach (Transform t in obj)
                {
                    AskColor(t,color);
                }
            }
        }

        protected virtual void Awake()
        {
            _gameObject = gameObject;
            _layer = GetGameObject.layer;
            _name = GetGameObject.name;
            _rigidbody = GetGameObject.GetComponent<Rigidbody>();
            _transform = transform;
            if (GetComponent<Renderer>())
            {
                _material = GetComponent<Renderer>().material;
            }
            if (GetComponent<MeshRenderer>())
            {
                _color = GetComponent<MeshRenderer>().material.color;
            }


        }

        private void AskLayer(Transform obj, int layer)
        {
            obj.gameObject.layer = layer;
            if (obj.childCount > 0)
            {
                foreach (Transform t in obj)
                {
                    AskLayer(t, layer);
                }
            }
        }



    }
}
