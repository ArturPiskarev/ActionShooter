using Shooter.Controller;
using UnityEngine;

public class FlashLightController : BaseController
{
    private float _timeLighting=500;
    private float _timeEnter=500;
    private Light _light;
    private float _minLighting=0f;

    public float TimeLighting
    {
        get { return _timeLighting; }
        set { _timeLighting = value; }
    }

    public float TimeEnter
    {
        get { return _timeEnter; }
        set
        {
            
            _timeEnter = value;
            _timeEnter = Mathf.Clamp(_timeEnter, _minLighting, _timeLighting);
        }
    }

    private void Start ()
	{
	    _light = GameObject.Find("Light").GetComponent<Light>();
        SetActiveFlashLight(false);
    }
	
	
	private void Update () {
	    if (!IsEnable)
	    {
	        TimeEnter++;
           // Debug.Log(_timeEnter);
            return;
	    }
	    if (IsEnable)
	    {
            //_timeEnter = Mathf.Clamp(_timeEnter, 0, 500);
            TimeEnter --;
	        if (TimeEnter<= 1)
	        {
	            Off();
	        }
           // Debug.Log(_timeEnter);
	    }

	}
    public override void On()
    {
        if (IsEnable) { return;}
        base.On();
        SetActiveFlashLight(true);
    }

    public override void Off()
    {
        if (!IsEnable) { return; }
        base.Off();
        SetActiveFlashLight(false);
    }

    private void SetActiveFlashLight(bool value)
    {
        _light.enabled = value;
    }

    public float Current()
    {
        return _timeEnter / _timeLighting;
    }
}
