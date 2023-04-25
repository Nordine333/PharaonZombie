using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class sceneController : MonoBehaviour
 {
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMenuScene() 
    {
		CurseurOn();
        SceneManager.LoadScene("MenuScene");
    }
    
    public void LoadCreditsScene() 
    {
		CurseurOn();
        SceneManager.LoadScene("Credits");
    }

    public void NextScene() 
    {
		CurseurOff();
		QualitySettings.SetQualityLevel(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadScene() 
    {
	   CurseurOff();
	   QualitySettings.SetQualityLevel(0);
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void QuitGame() {
		Application.Quit();
	}
	
	public void CurseurOn()
	{
		Cursor.visible = true;
	}
	
	public void CurseurOff()
	{
		Cursor.visible = false;
	}
	
}
