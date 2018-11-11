﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public GameObject firstBrick;
    public GameObject WallController;
    public string text = "Test es testet Test testet set test teste";
    public int lineLength = 5;
    static List<GameObject> list = new List<GameObject>();


    void Start () {
        list.Add(firstBrick);

        for (int index = 1; index < text.Length; index++)
        {
            GameObject newCube = Instantiate(firstBrick, WallController.GetComponent<Transform>());
            list.Add(newCube);
            newCube.GetComponent<Cube>().setup(firstBrick, text[index], (int)index / lineLength, index % lineLength);   
        }
        firstBrick.GetComponent<Cube>().setup(firstBrick, text[0], 0, 0);
    }

    private void Update()
    {
        // focusing a button
        if (null != Interact.focused && Interact.pressedE && "pressable" == Interact.focused.tag && ("WordPuzzleButton" == Interact.focused.name || "WordPuzzleButton(Clone)" == Interact.focused.name))
        {
            Interact.focused.GetComponent<Cube>().press();
        }
    }

    
}
