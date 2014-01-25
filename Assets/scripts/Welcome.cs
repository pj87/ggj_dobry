using UnityEngine;
using System.Collections;

public class Welcome : MonoBehaviour
{
    public float menuTimeout;

    private bool _showMenu = false;

    private float _menuWidth = 400f;
    private float _menuHeight = 250f;
    private float _buttonWidth = 300f;
    private float _buttonHeight = 30f;
    private float _buttonLeft;
    private float _buttonSpacing;

    private Rect _menuRect;

	// Use this for initialization
	void Start ()
    {
        
        var menuLeft = (Screen.width - _menuWidth) * 0.5f;
        var menuTop = (Screen.height - _menuHeight) * 0.5f;

        _buttonLeft = (_menuWidth - _buttonWidth) * 0.5f;
        _buttonSpacing = 10f;

        _menuRect = new Rect(menuLeft, menuTop, _menuWidth, _menuHeight);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > menuTimeout)
        {
            _showMenu = true;
        }
	}

    void OnGUI()
    {
        if (_showMenu)
        {
            GUI.Window(0, _menuRect, DrawMenu, "Menu");
        }
    }

    void DrawMenu(int windowId)
    {
        var x = _buttonLeft;
        var y = _buttonLeft;
        if (GUI.Button(new Rect(x, y, _buttonWidth, _buttonHeight), "Start"))
        {
            Application.LoadLevel("game");
        }
        y += _buttonHeight + _buttonSpacing;
        if (GUI.Button(new Rect(x, y, _buttonWidth, _buttonHeight), "Exit"))
        {
            Application.Quit();
        }
    }
}
