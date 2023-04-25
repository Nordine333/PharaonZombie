using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showDoorTextBuy : MonoBehaviour
{
	//Porte
	private porte doorForBuy;
	
	//Canvas
	public Text doorTextBuy;
	
    // Start is called before the first frame update
    void Start()
    {
        doorForBuy = GetComponent<porte>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
     void OnCollisionEnter(Collision col)
    {
		if(col.gameObject.tag == "Player")
		{
			doorTextBuy.text = doorForBuy.affichageAchatPorte(); //maj de l'affichage
			doorTextBuy.GetComponent<Text>().enabled = true; //activation de l'affichage
		}
		
	}
	
	 void OnCollisionExit(Collision col)
    {
		if(col.gameObject.tag == "Player")
		{
			doorTextBuy.text = ""; //clean affichage
			doorTextBuy.GetComponent<Text>().enabled = false; //desactivation de l'affichage
		}
		
	}
	
	public void eraseText()
	{
		doorTextBuy.text = ""; //clean affichage
		doorTextBuy.GetComponent<Text>().enabled = false; //desactivation de l'affichage
	}
}
