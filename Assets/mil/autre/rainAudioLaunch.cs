using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainAudioLaunch : MonoBehaviour
{
	//audio pluie
	private AudioSource audioSource;
	
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        //audio pluie : lancement de la boucle
		audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
