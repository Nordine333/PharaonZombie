using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easterEgg : MonoBehaviour
{
    //audio EasterEgg
	private AudioSource audioSource;
	
	//compteur de radio
	private int compteur = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void LaunchMusic()
    {
		audioSource.Play();
	}
    
    public void IncrementeCompteur()
    {
		compteur += 1;
		if(compteur == 3)
		{
			Invoke("LaunchMusic", 6f);
		}
	}
}
