using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

    GameObject player; 
    GameObject finish; 

    bool playerKilled_; 
    bool playerFinished_;
    bool changeScreen_; 

    public void setPlayerKilled(bool p) 
    { 
        playerKilled_ = p; 
    } 

    public void setPlayerFinished(bool p) 
    { 
        playerFinished_ = p; 
    } 

	// Use this for initialization
	void Start () { 
        player = GameObject.Find("Player");
        finish = GameObject.Find("Finish");

        playerKilled_ = false;
        playerFinished_ = false;
        changeScreen_ = false; 
	}

    public void goToCredits() {
        Application.LoadLevel("welcome");
    }

	// Update is called once per frame
	void Update () {
        if (changeScreen_ == true)
        {
            changeScreen_ = false;
            Invoke("goToCredits", 4); 
            //Application.LoadLevel("welcome"); 
        } 
        //if (player.GetComponent<Character>().getPlayerHp() <= 0)
            //DisplayResult(); 
	} 

    void DisplayResult() 
    {
        if (playerKilled_ == true)
        {
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height / 2, 400, 50)); 
            GUILayout.Label("You died... you miserable piece of meat...");
            GUILayout.EndArea();
            changeScreen_ = true; 
        } 
        else if (playerFinished_ == true)
        {
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height / 2, 400, 50)); 
            GUILayout.Label("You have survived... for now..."); 
            GUILayout.EndArea();
            changeScreen_ = true; 
        }
    } 

    void OnGUI() 
    { 
        DisplayResult(); 
    } 
}
