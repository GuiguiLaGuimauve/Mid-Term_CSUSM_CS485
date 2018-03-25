﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public void changeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void quitApplication()
    {
        Application.Quit();
    }
}
