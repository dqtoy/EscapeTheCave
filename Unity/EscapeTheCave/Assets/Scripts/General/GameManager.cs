﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public static class GameManager
{

    // Objects
    public static GameObject focused;
    public static GameObject Player;
    public static CameraEffectsScript cameraEffects;

    // States
    public static bool isGamePaused = false;
    public static bool secondCaveReached = false;
    public static bool isRecentlyRespawned = false;
    [SerializeField] public static bool isWordPuzzleSolved = false;
    public static bool isLightPuzzleSolved = false;
    public static bool isDiaryOpened = false;
    
    // Keys TODO switch to Unity input like inventory 
    public static bool pressedInteractKey = false;
    public static bool pressedL1Key = false; // previous page
    public static bool pressedR1Key = false; // next page
    public static bool pressedL2Key = false; 
    public static bool pressedR2Key = false; // toggle diary
    
    // Vars
    public static string hoverMessage = "This is the maximum length of the message; This is the maximum length of the message; This is the maximum length of the message; This is the maximum length of the message";
	public static Vector3 monsterPosition;
	public static MonsterZone[] monsterZones = new MonsterZone[5];

    public static void UnpressAllKeys()
    {
        pressedInteractKey = false;
        pressedL1Key = false;
        pressedR1Key = false;
        pressedL2Key = false;
        pressedR2Key = false;
    }

    public static bool IsGamepadConnected
    {
        get
        {
            bool isConnected = Input.GetJoystickNames().Length > 0;
            if (isConnected)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
//                Cursor.visible = true;
//                Cursor.lockState = CursorLockMode.None;
//                Cursor.visible = false;
//                Cursor.lockState = CursorLockMode.Locked;
            }
            return isConnected;
        }
    }

    public static void LoadCurrentLevel()
    {
        // very simple atm
        if (secondCaveReached) ResetSecondCave();
    }

    public static void ResetSecondCave()
    {
        Player.transform.position = new Vector3(-24.1f, -0.56f, 1.32f);
//        Player.transform.position = new Vector3(-141.53f, -2.876f, -10.72f);
//        Player.transform.eulerAngles = new Vector3(0.0f, 253.74f, 0.0f);
        Player.transform.LookAt(GameObject.Find("SecondCaveLookAtTarget").transform.position);
        Player.GetComponent<FirstPersonController>().rootRotation = Player.transform.rotation;
        Player.GetComponent<FirstPersonController>().resetRotation = true;
        JumpStone.reset = true;
        GameObject.Find("SoundSystem").GetComponents<AudioSource>()[1].enabled = false;
        foreach (var monsterZone in monsterZones)
        {
            monsterZone.Reset();
            monsterZone.isActive = false;
        }
    }

    public static void Die()
    {
        isRecentlyRespawned = true;
        cameraEffects.currentBlur = 5;
        ResetSecondCave();
    }
}
