using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Arme : MonoBehaviour
{
	//text
	public Text munitionText;
	
	//audio
	private AudioSource audioSource;
	
	public AudioClip shoot;
	public AudioClip reload;
	public AudioClip noAmmo;

	//attribut de la classe arme
    public string nom;
    public string typeArme;
    public int prix_weapon;
    public int prix_ammo;
    public int degats;
    public float portee;
    public float delaiAtk;
    public int nbMunitionsTotalCurrent;
    public int nbMunitionsChargeurCurrent; 
    private int nbMunitionsChargeurMax;
    private int nbMunitionsTotalMax;
	
	//pariticule
	public ParticleSystem tirParticle;

	//position de l'arme avant achat
    private Vector3 startPosition;
    private Quaternion startRotation;
	
	 // Start is called before the first frame update
    void Start()
    {    
		nbMunitionsChargeurMax = nbMunitionsChargeurCurrent;
		nbMunitionsTotalMax = nbMunitionsTotalCurrent;
        startPosition = transform.position;
        startRotation = transform.rotation;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public string affichageAchatArme() 
    {
        return "Hold E to buy " + nom + " [Cost: " + prix_weapon + "]";
    }
    
    public string affichageAchatAmmo() 
    {
        return "Hold E to buy ammo [Cost: " + prix_ammo + "]";
    }
    
    public void rechargeArme()
    {
		if(nbMunitionsTotalCurrent !=0)
		{
			if(nbMunitionsTotalCurrent >= nbMunitionsChargeurMax) //si on a suffisament de mun dispo on recharge entierement
			{
				nbMunitionsChargeurCurrent = nbMunitionsChargeurMax; // remplie chargeur
				nbMunitionsTotalCurrent -=  nbMunitionsChargeurMax; //recharge en remplissant le chargeur au max
			}
			else //sinon partiellement
			{
				nbMunitionsChargeurCurrent = nbMunitionsTotalCurrent; // remplie chargeur
				nbMunitionsTotalCurrent = 0; //recharge en prenant le nombre de balles restantes
			}
			
			//possible implementation animation de rechargement
			
			//audio rechargeArme
			audioSource.clip = reload;
			audioSource.Play();
		}
		else 
		{
			//audio tir avec chargeur vide
			audioSource.clip = noAmmo;
			audioSource.Play();
		}
	}
    
    public void armeTir()
    {		
		if(nbMunitionsChargeurCurrent == 0)
		{
			rechargeArme();
		}
		else 
		{			
			nbMunitionsChargeurCurrent -= 1;
			MajAmmoText();
			
			//particule de tir
			tirParticle.Play();
			
			//audio tir arme
			audioSource.clip = shoot;
			audioSource.Play();
		}
		MajAmmoText();
	}
	
	public void MajAmmoText()
	{
		// mise à jour de l'affichage ammo
		munitionText.text = nbMunitionsChargeurCurrent.ToString() + " / " + nbMunitionsTotalCurrent.ToString(); 
	}
	
	public void EraseWeapon()
	{
		GetComponent<ParentConstraint>().enabled = false;
		transform.position = startPosition;
		transform.rotation = startRotation;
		GetComponent<showTextBuy>().setAlreadyBuy(false);
	}
	
	public int getDegats()
	{
		return degats;
	}
	
	public float getDelaiAtk()
	{
		return delaiAtk;
	}
	
	public string getTypeArme()
	{
		return typeArme;
	}
	
	public int getPrixWeapon()
	{
		return prix_weapon;
	}
	
	public int getPrixAmmo()
	{
		return prix_ammo;
	}
	
	public float getPortee()
	{
		return portee;
	}
	
	public float getAmmo()
	{
		return nbMunitionsChargeurCurrent;
	}
	
	public void refillAmmo() //recharge les munitions au max
	{
		nbMunitionsChargeurCurrent = nbMunitionsChargeurMax;
		nbMunitionsTotalCurrent = nbMunitionsTotalMax;
		MajAmmoText();
	}
	
	public bool isFullAmmo()
	{
		return (nbMunitionsTotalCurrent == nbMunitionsTotalMax) && (nbMunitionsChargeurCurrent == nbMunitionsChargeurMax);
	}
}
