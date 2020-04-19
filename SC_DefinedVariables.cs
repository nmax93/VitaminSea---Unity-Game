using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DefinedVariables {

    public static Dictionary<string, GameObject> Screens;
    public static int maxSlots = 64;
    public static Dictionary<string, GameObject> Slots;
    public static GameObject Empowerments;
    public static List<SC_GlobalEnums.Fruits> Slot_values;
    public static List<int> Empowered_slots;
    public static int Score = 0;
    public static int prev_score = 0;
    public static int Level = 1;
    public static int Target = 4000;

    public static bool IsMyTurn = false;
    public static bool multiplayer = true;
    public static string userName = "";
    public static string password = "";
    public static List<int> Gap_Filling_Values;
    public static int Gap_Filling_Counter = 0;
    public static int MyScore = 0;
    public static int OpScore = 0;
}
