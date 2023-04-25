using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showTextBuy : MonoBehaviour
{
	//Arme
	private Arme armeForBuy;

	//Canvas
	public Text weaponTextBuy;
	
	//etat
	private bool alreadyBuy = false;
	
    // Start is called before the first frame update
    void Start()
    {
        armeForBuy = GetComponent<Arme>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider col)
    {
		if(col.tag == "Player" && !alreadyBuy)
		{
			weaponTextBuy.text = armeForBuy.affichageAchatArme(); //maj de l'affichage
			weaponTextBuy.GetComponent<Text>().enabled = true; //activation de l'affichage
		}
		else 
		{
			//affichage pour ammo
		}
		
	}
	
	 void OnTriggerExit(Collider col)
    {
		if(col.tag == "Player" && !alreadyBuy)
		{
			weaponTextBuy.text = ""; //clean affichage
			weaponTextBuy.GetComponent<Text>().enabled = false; //desactivation de l'affichage
		}
		else 
		{
			//affichage pour ammo
		}
		
	}
	
	public void setAlreadyBuy(bool newState)
	{
		alreadyBuy = newState;
		weaponTextBuy.GetComponent<Text>().enabled = false;
	}
}
