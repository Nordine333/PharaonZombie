using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundGestion : MonoBehaviour
{
	//Point d'apparition des mobs
	public List<Transform> mobSpawner;
	
	//Mob Prefab
	public GameObject zombiePrefab;
	public GameObject chienPrefab;
	
	//Canvas
	public Text textManche;
	public Text textZombieRestant;
	
	//audio
	private AudioSource audioSource;

	
	//Info round actuel
	const int nbZombieDefault = 1;
	private int nbZombies;
	private int numManche = 0;
	private float multZombieHealth = 0.95f;
	private float multZombieForce = 0.98f;
	
    // Start is called before the first frame update
    void Start()
    {
		nbZombies = nbZombieDefault;
        ProchaineManche(); // initialise manche 1
        audioSource = GetComponent<AudioSource>();

    }
    
 

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void GenereMob(GameObject mob)
    {
		for(int i=0; i<nbZombies; i=i+1)
		{
			int indexRand = Random.Range(0, mobSpawner.Count - 1); //obtient un index de MobSpawner aleatoire
			GameObject currentMob = Instantiate(mob, mobSpawner[indexRand].position, Quaternion.identity); //fait spawn un ennemi sur un mobSpawner random
			mobStats.vieMobMax = (int) (100f * multZombieHealth);
			mobAttack.valeurAttackMob = (int) (25f * multZombieForce);
		}
	}
    
    void ProchaineManche()
    {		
		multZombieHealth += 0.05f;
		multZombieForce += 0.02f;
		numManche +=1;                                                                       // (=8)
		nbZombies = nbZombieDefault + 2*numManche; // le nombre de zombie pour manche n = nbZombieDefault + 2n
		if(numManche%5==0) // tout les 5 rounds c'est une manche speciale
		{
			GenereMob(zombiePrefab); // IMPLEMENTER LE PREFAB DE L'ARAIGNEE PROCEDURALE ICI 
		}
		else
		{
			GenereMob(zombiePrefab);
		}
		textZombieRestant.text = nbZombies.ToString();
		textManche.text = numManche.ToString();
		// activr multZombie health et force
	}
	
	
	public void SignalEnnemiMort()
	{
		nbZombies -=1;
		textZombieRestant.text = nbZombies.ToString();
		// fin de la manche
		if(nbZombies == 0) 
		{
			//manche suivante
			Invoke("ProchaineManche", 9.5f); 
			
			//audio fin de manche
			audioSource.Play();
		}
		
		
	}
	
	public void AddNewMobSpawn(List<Transform> newSpawnList)
	{
		mobSpawner.AddRange(newSpawnList);
	}
}
