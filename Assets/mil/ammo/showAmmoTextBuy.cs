using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showAmmoTextBuy : MonoBehaviour
{
    //Canvas
	public Text ammoTextBuy;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider col)
    {
		if(col.gameObject.tag == "Player")
		{
			Arme currentWeapon = col.gameObject.GetComponent<attaquePlayer>().arme; //récupère l'arme actuelle
			ammoTextBuy.text = affichageAchatAmmo(currentWeapon.getPrixAmmo()); //maj de l'affichage
			ammoTextBuy.GetComponent<Text>().enabled = true; //activation de l'affichage
		}
		
	}
	
	 void OnTriggerExit(Collider col)
    {
		if(col.gameObject.tag == "Player")
		{
			ammoTextBuy.text = ""; //clean affichage
			ammoTextBuy.GetComponent<Text>().enabled = false; //desactivation de l'affichage
		}
		
	}
    
    public string affichageAchatAmmo(int prixAmmo) 
    {
        return "Hold E to buy Ammo [Cost: " + prixAmmo + "]";
    }
}
