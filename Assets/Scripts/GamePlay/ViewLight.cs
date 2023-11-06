using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewLight : MonoBehaviour
{
    [SerializeField]
    private GameObject _fire;
    private Light _pointLight;
    private int _lightValue= 14;
    private void Start() {
            _pointLight = _fire.GetComponent<Light>();
        }
    public void SetValue(int lightValue) {
        _lightValue=lightValue;
        if (_pointLight != null){
            _pointLight.intensity = _lightValue;
        }
    }
}
