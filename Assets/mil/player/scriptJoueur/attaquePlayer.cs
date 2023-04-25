using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class attaquePlayer : MonoBehaviour
{
	//arme
	public Arme arme;
	public GameObject knifeMesh;
	
	//gestion interaction tir 
	private bool isFiring = false;
    private InputAction fireAction;
    
	//compteur de temps
	private float NextFenetreAtk;
	
	//viseur
	private Ray ray;
	private RaycastHit hit;
	
	//animation 
	private Animator animatorPlayer;
	public Animator animatorHands;
	
	//camera
	public GameObject cameraActif;
	
    // Start is called before the first frame update
    void Start()
    {
        NextFenetreAtk = Time.time;
        animatorPlayer = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        fireAction = GetComponent<PlayerInput>().actions.FindAction("LeftAttack");
        fireAction.started += OnShootStarted;
        fireAction.canceled += OnShootCanceled;
        fireAction.Enable();
    }

    private void OnDisable()
    {
        fireAction.started -= OnShootStarted;
        fireAction.canceled -= OnShootCanceled;
        fireAction.Disable();
    }

    private void Update()
    {
        if (isFiring && Time.time >= NextFenetreAtk)
        {
            AttackFire();
            NextFenetreAtk = Time.time + arme.getDelaiAtk(); // calcule prochain fenetre d'atk		
        }
    }

    private void OnShootStarted(InputAction.CallbackContext context)
    {
        isFiring = true;
    }

    private void OnShootCanceled(InputAction.CallbackContext context)
    {
        isFiring = false;
    }
    
    private void AttackFire()
    {
		arme.armeTir();
		if(arme.getAmmo() != 0)
		{
			//animatorPlayer.SetTrigger("shotReculAnim");
			ray = cameraActif.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f,0.5f));
			if(Physics.Raycast(ray, out hit,arme.getPortee())) // tire raycast de taille "portee" depuis le centre de la caméra (viseur)
			{	
				//gerer detection mob et infliger degats
				if(hit.transform.tag == "Ennemi")
				{
					hit.transform.gameObject.GetComponent<mobStats>().setVie(arme.getDegats());
					Debug.Log("degats infligés "+arme.getDegats());
					// argent gagnée selon l'etat de l'ennemi (possible implementation des parties de corps touchés qui rapporte +)
					int vieEnnemiTouchee = hit.transform.gameObject.GetComponent<mobStats>().getVie();
					if(vieEnnemiTouchee != 0) GetComponent<argentPlayer>().setArgent(10);
					else GetComponent<argentPlayer>().setArgent(100);

				}
				if(hit.transform.tag == "Radio") hit.transform.gameObject.GetComponent<radio>().radioActivation();
			}
		}
	}

	private void OnKnife()
	{
		knifeMesh.SetActive(true);
		
		float porteeKnife = 2.5f;

		animatorHands.SetTrigger("knife");
		ray = cameraActif.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f,0.5f));
			if(Physics.Raycast(ray, out hit,porteeKnife)) // tire raycast de taille "porteeKnife" depuis le centre de la caméra (viseur)
			{	
				//gerer detection mob et infliger degats
				if(hit.transform.tag == "Ennemi")
				{
					StartCoroutine(KnifeAttackTimeOffset(0.5f));
					// possible implementation des parties de corps touchés qui rapporte +
					int vieEnnemiTouchee = hit.transform.gameObject.GetComponent<mobStats>().getVie();
					if(vieEnnemiTouchee != 0) GetComponent<argentPlayer>().setArgent(10);
					else GetComponent<argentPlayer>().setArgent(100);

				}
				if(hit.transform.tag == "Radio") hit.transform.gameObject.GetComponent<radio>().radioActivation();
			}
		StartCoroutine(retablirAnimationArme(0.8f));
	}

	IEnumerator KnifeAttackTimeOffset(float time) //retarde l'attaque avec un couteau pour synchroniser l'animation et les dégâts
	{
		yield return new WaitForSeconds(time);
		int degatsKnife = 50;
		hit.transform.gameObject.GetComponent<mobStats>().setVie(degatsKnife);// argent gagnée selon l'etat de l'ennemi
	}

	IEnumerator retablirAnimationArme(float time)
	{
        yield return new WaitForSeconds(time);
		switch (arme.getTypeArme())  //animation differente selon l'arme porté
					{
						case "Pistol": 
							animatorHands.SetTrigger("pistolet");
							break;
						case "AssautRiffle": 
							animatorHands.SetTrigger("ar");
							break;
						case "Shotgun": 
							animatorHands.SetTrigger("shotgun");
							break;
					}
					knifeMesh.SetActive(false);
	}
	
	
	public void SetArme(Arme newWeapon)
	{
		arme = newWeapon;
		arme.MajAmmoText();
	}
	
	public Arme GetArme()
	{
		return arme;
	}
}
