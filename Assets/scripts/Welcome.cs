using UnityEngine;
using System.Collections;

public class Welcome : MonoBehaviour
{
    public enum Mode
    {
        Invalid,
        Init,
        Menu,
        Credits
    }

    public float initialCreditsDelay = 7f;

    public float _guiAlpha = 0;

    private bool _areStylesInitialized = false;
    private GUIStyle _styleCreditsTitle;
    private GUIStyle _styleCreditsNames;

    public static Mode initialMode = Mode.Init;
    private Mode _mode = Mode.Invalid;
    private bool _modeChanging = false;

    private Rect _menuRect;
    private Rect _creditsRect;

    private string[] _creatorNames;

	void Start()
    {
        Debug.Log("start");
        float menuWidth = 300f;
        float menuHeight = 250f;
        float creditsWidth = 450f;
        float creditsHeight = 300f;

        var menuLeft = (Screen.width - menuWidth) * 0.5f;
        var menuTop = (Screen.height - menuHeight) * 0.5f;
        var creditsLeft = (Screen.width - creditsWidth) * 0.5f;
        var creditsTop = (Screen.height - creditsHeight) * 0.5f;

        _menuRect = new Rect(menuLeft, menuTop, menuWidth, menuHeight);
        _creditsRect = new Rect(creditsLeft, creditsTop, creditsWidth, creditsHeight);

        _creatorNames = new string[]
        {
            "Programming: Arek Dygas",
            "Programming: Piotr Łukaszewicz",
            "Programming: Paweł Jastrzębski", 
            "Graphics: Piotr Trzebiński" 
        };

        ChangeMode(initialMode);
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnGUI()
    {
        var color = GUI.color;
        color.a = _guiAlpha;
        GUI.color = color;

        if (!_areStylesInitialized)
        {
            InitStyles();
        }

        switch (_mode)
        {
            case Mode.Init:
                ShowCredits();
                if (Time.time > initialCreditsDelay)
                {
                    ChangeMode(Mode.Menu);
                }
                break;
            case Mode.Menu:
                ShowMenu();
                break;
            case Mode.Credits:
                ShowCredits();
                break;
            default:
                Debug.LogError("Invalid mode: " + _mode);
                break;
        }
    }

    private void InitStyles()
    {
        _styleCreditsTitle = new GUIStyle(GUI.skin.label);
        _styleCreditsTitle.alignment = TextAnchor.MiddleCenter;
        _styleCreditsTitle.fontStyle = FontStyle.Bold;
        _styleCreditsTitle.fontSize = 26;
        _styleCreditsTitle.normal.textColor = Color.gray;

        _styleCreditsNames = new GUIStyle(GUI.skin.label);
        _styleCreditsNames.alignment = TextAnchor.MiddleCenter;
        _styleCreditsNames.fontSize = 18;
        _styleCreditsNames.normal.textColor = Color.gray;
    }

    void ShowMenu()
    {
        float buttonSpacing = 5f;

        GUILayout.BeginArea(_menuRect);
        GUILayout.BeginVertical();

        if (MenuHelper.GUILayoutButton("Start"))
        {
            Application.LoadLevel("testEnemy");
        }
        GUILayout.Space(buttonSpacing);
        if (MenuHelper.GUILayoutButton("Credits"))
        {
            ChangeMode(Mode.Credits);
        }
        GUILayout.Space(buttonSpacing);
        if (MenuHelper.GUILayoutButton("Exit"))
        {
            Application.Quit();
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void ShowCredits()
    {
        GUILayout.BeginArea(_creditsRect);
        GUILayout.BeginVertical();

        GUILayout.Label("PolyJam 2014", _styleCreditsTitle);
        GUILayout.Space(30f);

        foreach (var name in _creatorNames)
        {
            GUILayout.Label(name, _styleCreditsNames, GUILayout.ExpandWidth(true));
            GUILayout.Space(7f);
        }

        if (_mode == Mode.Credits)
        {
            if (MenuHelper.GUILayoutButton("Back"))
            {
                ChangeMode(Mode.Menu);
            }
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    private void ChangeMode(Mode mode)
    {
        StartCoroutine(ChangeModeCoroutine(mode));
    }

    private IEnumerator ChangeModeCoroutine(Mode mode)
    {
        Debug.Log("mode changing: " + mode);
        if (_modeChanging)
        {
            yield break;
        }

        _modeChanging = true;

        if (mode != Mode.Init)
        {
            // fade out
            while(_guiAlpha > 0)
            {
                _guiAlpha = Mathf.Clamp01(_guiAlpha - Time.deltaTime * 0.5f);
                yield return null;
            }
        }
        _mode = mode;
        // fade in
        while (_guiAlpha < 1)
        {
            _guiAlpha = Mathf.Clamp01(_guiAlpha + Time.deltaTime * 0.5f);
            yield return null;
        }

        _modeChanging = false;
    }
}
