using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cameraPlayerSwticher : MonoBehaviour
{
	private GameObject TPS;
	private GameObject FPS;
	
	private bool estEnVueTPS = true;
	
    // Start is called before the first frame update
    void Start()
    {
        TPS = transform.GetChild(0).gameObject;
        FPS = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnVueSwitch() // change de vue entre FPS et TPS
    {   
        estEnVueTPS = !estEnVueTPS;
        if(estEnVueTPS) 
        {
			FPS.SetActive(false); 
			TPS.SetActive(true);
			
			// la camera qui fait office de viseur est mis a jour
			transform.parent.gameObject.GetComponent<attaquePlayer>().cameraActif = TPS;		}
        else 
        {
			TPS.SetActive(false);
			FPS.SetActive(true); 
			
			transform.parent.gameObject.GetComponent<attaquePlayer>().cameraActif = FPS;
		}
    }
}
