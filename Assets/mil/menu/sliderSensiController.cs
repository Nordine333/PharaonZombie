using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderSensiController : MonoBehaviour
{
	private Slider slider;
	private float sensibilitee = 0.5f;
	
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setSpeedSensi()
    {
        sensibilitee = slider.value;
        CameraFollowMouse.speed = sensibilitee;
    }
}

