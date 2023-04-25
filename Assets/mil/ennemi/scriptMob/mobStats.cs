using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mobStats : MonoBehaviour
{
	//RoundManager
	public GameObject RoundManager;

	//vie
	public static int vieMobMax = 100;
	private int vieMob;
	private bool mort = false;
	
	private Animator mobAnim;
	private NavMeshAgent mobMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        vieMob = vieMobMax;
        mobMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        mobAnim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void MobMeurt()
    {
		mort = true;
		mobMeshAgent.Stop();
		mobAnim.SetTrigger("die");
		BoxCollider boxCollider = GetComponent<BoxCollider>(); // je desactive les collissions avec l'ennemi mort
		if (boxCollider != null) boxCollider.enabled = false;
		RoundManager.GetComponent<roundGestion>().SignalEnnemiMort(); // maj du nombre de zombie restant
		Destroy(gameObject,10f); // après 10 secondes detruit l'objet mob
		
	}
	
	public void setVie(int valAtk)
	{
		vieMob -= valAtk;
		GetComponent<ParticleSystem>().Play(); //particule de sang qui tombe lorsque l'ennemi est touché
		vieMob = Mathf.Clamp(vieMob,0,vieMobMax);
		Debug.Log(vieMob);
		if(vieMob <= 0) MobMeurt();
	}
	
	public int getVie()
	{
		return vieMob;
	}
	
	public bool getMort()
	{
		return mort;
	}
}
