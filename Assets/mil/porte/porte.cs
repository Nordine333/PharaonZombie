using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porte : MonoBehaviour
{
	public int prixPorte;
	public GameObject roundManager;
	public List<Transform> newSpawnList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void EnableNewSpawn()
    {
		roundManager.GetComponent<roundGestion>().AddNewMobSpawn(newSpawnList);
	}
    public string affichageAchatPorte() 
    {
        return "Hold E to open Door [Cost: " + prixPorte + "]";
    }
    
    public void DestructDoor()
    {
		GetComponent<showDoorTextBuy>().eraseText();
		EnableNewSpawn();
		Destroy(gameObject);
	}
	
	public int getPriceDoor()
	{
		return prixPorte;
	}
}
