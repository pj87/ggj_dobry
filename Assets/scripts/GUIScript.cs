using UnityEngine; 
using System.Collections; 

public class GUIScript : MonoBehaviour { 
    public GUIStyle style; 
    public float life = 93; 
    void OnGUI() 
    {
        GUI.Box(new Rect(10, 10, Screen.width / 2 / (life / 100.0f), 25), life + "/" + 100); 

        GUILayout.BeginArea(new Rect(Screen.width-200, 0, 5000, 500)); 
        //Tutaj można sobie forem wyświetlać jakieś fajne listy 
        //GUILayout.BeginVertical 
        GUILayout.Label("ŻYCIE: " + life, style); 
        //Z boku pasek do przewijania 
        //GUILayout.BeginScrollView 
        GUILayout.EndArea(); 
    } 
} 
