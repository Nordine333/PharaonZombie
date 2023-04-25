using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyDoorPlayer : MonoBehaviour
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
			//gerer detection arme au murs et l'achat
			if(hit.transform.tag == "Door")
			{
				porte DoorToBuy = hit.transform.gameObject.GetComponent<porte>();
				if(playerArgent.getArgent() >= DoorToBuy.getPriceDoor())
				{
					//implementer : activer les nouveaux mobs spawnner
					playerArgent.setArgent(-DoorToBuy.getPriceDoor()); //retire l'argent de l'achat						
					DoorToBuy.DestructDoor();			
				}
			}
		}
	}
}
