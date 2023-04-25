using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobAttack : MonoBehaviour
{
	// joueur position
	public Transform targetPlayer;
	
	// attaque
	private RaycastHit hit;
	public float DistanceToAttack = 2;
	private float DistanceToPlayer;
	public float delaiAtk = 4; // temps a attendre entre 2 attaques
	private float NextFenetreAtk; // prochain temps minimal a atteindre pour attaquer
	public static int valeurAttackMob = 25;

	// animation
	private Animator mobAnim;
	
    // Start is called before the first frame update
    void Start()
    {
        NextFenetreAtk = Time.time;
        mobAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
	   // met a jour la distance player - ennemi
	   DistanceToPlayer = Vector3.Distance(transform.position,targetPlayer.position); 
	   
       // attaque
		if(DistanceToPlayer < DistanceToAttack && !(GetComponent<mobStats>().getMort()))
		{
		   Debug.DrawRay(transform.position,this.transform.forward * DistanceToAttack, Color.blue);

		   if(Physics.Raycast(transform.position,this.transform.forward,out hit))
		   {
			   if("Player" == hit.transform.tag)
			   {
				   if(Time.time > NextFenetreAtk) // delai entre 2 attaques écoulé
				{
					//GetComponent<AudioSource>().PlayOneShot(attaqueSound);
					mobAnim.SetTrigger("attack");
					Debug.Log("Le mob atk");
					hit.transform.gameObject.GetComponent<statsPlayer>().setVie(valeurAttackMob);
					NextFenetreAtk = Time.time + delaiAtk; // calcule prochain fenetre d'atk
				}
				
				
			   }
				
			}
		}   
    }
}
