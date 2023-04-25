using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio : MonoBehaviour
{
	//audio radio
	private AudioSource audioSource;
	
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void radioActivation()
    {
		audioSource.Play();
        transform.parent.gameObject.GetComponent<easterEgg>().IncrementeCompteur();
        transform.localScale = Vector3.zero; // fait disparaitre l'objet sans le detruire (pour que l'audio puisse continuer à jouer)
    }
	
}
