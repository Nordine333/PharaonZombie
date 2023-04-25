using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sliderMusiqueController : MonoBehaviour
{
	private Slider slider;
	private float volumeMusique = 0.5f;
	
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setVolumeMusique()
    {
        volumeMusique = slider.value;
        AudioListener.volume = volumeMusique ;
    }
}

