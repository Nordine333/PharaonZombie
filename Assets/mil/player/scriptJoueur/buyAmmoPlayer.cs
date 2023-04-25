using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyAmmoPlayer : MonoBehaviour
{
	//viseur
	private Ray ray;
	private RaycastHit hit;
	
	//argent 
	private argentPlayer playerArgent;
	
    // Start is called before the first frame update
    void Start()
    {
		playerArgent = GetComponent<argentPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnInteractionBuy() 
    {
		ray = GetComponent<attaquePlayer>().cameraActif.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f,0.5f));
		if(Physics.Raycast(ray, out hit,1f))
		{	
			//gerer detection de la boite de munitions
			if(hit.transform.tag == "ammoBox")
			{
				Arme weaponCurrent = GetComponent<attaquePlayer>().arme;
				
				if(playerArgent.getArgent() >= weaponCurrent.getPrixAmmo() && !weaponCurrent.isFullAmmo())
				{
					weaponCurrent.refillAmmo();
					playerArgent.setArgent(-weaponCurrent.getPrixAmmo()); //retire l'argent de l'achat				
				}
			}
		}
	}
}
