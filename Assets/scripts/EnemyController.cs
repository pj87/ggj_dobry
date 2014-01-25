﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyController : MonoBehaviour {

    private int _activeVisionMode;
    private Character _playerScript;

    public float enemyInvisibleAlpha = 0.2f;
    public Material arachnidMaterial;
    public Material blobMaterial;
    public Material humanoidMaterial;

	// Use this for initialization
	void Start ()
    {
        foreach (var enemy in FindObjectsOfType<EnemyBehaviour>())
        {
            var renderer = enemy.GetComponentInChildren<Renderer>();
            if(enemy is ArachnidBehavior)
            {
                renderer.material = arachnidMaterial;
            }
            if(enemy is HumanoidBehavior)
            {
                renderer.material = humanoidMaterial;
            }
            if(enemy is GlutBehavior)
            {
                renderer.material = blobMaterial;
            }
        }

        _playerScript = GameObject.FindWithTag("Player").GetComponent<Character>();
        _activeVisionMode = _playerScript.VisionMode;
        UpdateEnemiesVisibility();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_activeVisionMode != _playerScript.VisionMode)
        {
            _activeVisionMode = _playerScript.VisionMode;
            UpdateEnemiesVisibility();
        }
	}

    private void UpdateEnemiesVisibility()
    {
        Color arachnidColor = arachnidMaterial.color;
        Color humanoidColor = humanoidMaterial.color;
        Color blobColor = blobMaterial.color;

        float arachnidAlpha = 1f;
        float humanoidAlpha = 1f;
        float blobAlpha = 1f;

        switch (_activeVisionMode)
        {
            case 0: // torchlight
                arachnidAlpha = enemyInvisibleAlpha;
                break;
            case 1: // blue
                humanoidAlpha = enemyInvisibleAlpha;
                break;
            case 2: // red
                blobAlpha = enemyInvisibleAlpha;
                break;
        }

        arachnidColor.a = arachnidAlpha;
        humanoidColor.a = humanoidAlpha;
        blobColor.a = blobAlpha;

        arachnidMaterial.color = arachnidColor;
        humanoidMaterial.color = humanoidColor;
        blobMaterial.color = blobColor;
    }
}
