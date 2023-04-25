using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class statsPlayer : MonoBehaviour
{
    //vie
	public int viePlayerMax = 100;
	private int viePlayer;
	public int valueHealthRegenerate = 25;
	
	public float NextFenetreRegeneration;
	public float delaiRegenDegatRecent = 5f;
	
	//post processing (ecran rouge low health)
	public PostProcessVolume volumeCameraTPS;
	public PostProcessVolume volumeCameraFPS;

	
    // Start is called before the first frame update
    void Start()
    {
        viePlayer = viePlayerMax;
        InvokeRepeating("HealthRegenerate", 0f, 10f); // appelle la fonction de regeneration de vie chaque seconde
        NextFenetreRegeneration = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void HealthRegenerate() // chaque seconde la vie est incrementer de quelques points de vie
    {
		if(Time.time > NextFenetreRegeneration) // delai a attendre pour se soignée apres degat récent
		{
			viePlayer += valueHealthRegenerate;
			viePlayer = Mathf.Clamp(viePlayer,0,viePlayerMax);
			LowHealthRedScreenMAJ();
		}
	}
    
    void JoueurMeurt()
    {
		Debug.Log("Le joueur est mort");
		Cursor.visible = true;
		SceneManager.LoadScene("Credits");
	}
	
	void LowHealthRedScreenMAJ()
	{
		Vignette vignette;
        if (volumeCameraTPS.profile.TryGetSettings(out vignette))
        {
            vignette.intensity.value = (((float) viePlayerMax - (float) viePlayer)/(float) viePlayerMax) * 0.6f;
        }
        if (volumeCameraFPS.profile.TryGetSettings(out vignette))
        {
            vignette.intensity.value = (((float) viePlayerMax - (float) viePlayer)/(float) viePlayerMax) * 0.6f;
        }
	}
	
	public void setVie(int valAtk)
	{
		viePlayer -= valAtk;
		viePlayer = Mathf.Clamp(viePlayer,0,viePlayerMax);
		LowHealthRedScreenMAJ();
		Debug.Log(viePlayer);
		if(viePlayer <= 0) JoueurMeurt();
		NextFenetreRegeneration = Time.time + delaiRegenDegatRecent; // calcule prochain fenetre de soin si des dégats recents sont subis
	}
	
	public int getVie()
	{
		return viePlayer;
	}
}
