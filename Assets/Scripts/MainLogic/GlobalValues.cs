﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalValues {

    public static float TimeLeft { get; set; }
    public static bool Running { get; set; }
    public static bool Lost { get; set; }
    public static bool Won { get; set; }
    public static GameObject currentCar { get; set; }

    static GlobalValues()
    {
        TimeLeft = 60;
        Running = false;
        Lost = false;
        Won = false;
        currentCar = null;
    }
}
