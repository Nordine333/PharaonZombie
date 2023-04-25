using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class argentPlayer : MonoBehaviour
{
	// Argent
	private int ArgentPlayer = 950;
	public Text argentText;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setArgent(int valDepense)
    {
		ArgentPlayer += valDepense;
		ArgentPlayer = Mathf.Max(0,ArgentPlayer); //argent jamais negatif
		argentText.text = ArgentPlayer.ToString(); // mise à jour de l'affichage argent
	}
	
	public int getArgent()
	{
		return ArgentPlayer;
	}
}
