using AssemblyCSharp;
using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Logic : MonoBehaviour
{
    private bool SwapMonstersBack = true;
    private GameObject ScoreObject;
    public AudioSource Boom;

    static SC_Logic instance;
    public static SC_Logic Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("SC_Logic").GetComponent<SC_Logic>();
            return instance;
        }
    }

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Button");
        SC_DefinedVariables.Slots = new Dictionary<string, GameObject>();
        foreach (GameObject o in objects)
            SC_DefinedVariables.Slots.Add(o.name, o);

        SC_DefinedVariables.Screens = new Dictionary<string, GameObject>();
        GameObject[] screens = GameObject.FindGameObjectsWithTag("Screen");
        foreach (GameObject o in screens)
            SC_DefinedVariables.Screens.Add(o.name, o);

        SC_DefinedVariables.Empowerments = new GameObject();
        SC_DefinedVariables.Empowerments = GameObject.FindGameObjectWithTag("Empowerments");
        for(int i = 0; i < SC_DefinedVariables.maxSlots; i++)
            SC_DefinedVariables.Empowerments.transform.GetChild(i).GetComponent<SC_Empowerments>().EmpImage.enabled = false;

        ScoreObject = GameObject.FindGameObjectWithTag("Score");

        SC_DefinedVariables.Screens["Loading_screen"].SetActive(false);
        SC_DefinedVariables.Screens["LevelComplete_screen"].SetActive(false);
        SC_DefinedVariables.Screens["Login_screen"].SetActive(false);
    }

    public void InitBoard()
    {
        SC_GlobalEnums.Fruits state;
        SC_DefinedVariables.Slot_values = new List<SC_GlobalEnums.Fruits>();
        SC_DefinedVariables.Empowered_slots = new List<int>();

        state = (SC_GlobalEnums.Fruits)Random.Range(1, 8);
        SC_DefinedVariables.Slot_values.Add(state);
        SC_DefinedVariables.Empowered_slots.Add(0);
        SC_DefinedVariables.Slots["Slot0"].GetComponent<SC_Slot>().Change_slot_state(state);
        SC_DefinedVariables.Slots["Slot0"].GetComponent<SC_Slot>().SlotSelectedImage.enabled = false;
        SC_DefinedVariables.Slots["Slot0"].GetComponent<SC_Slot>().SlotEmpowerImage.enabled = false;

        for (int i = 1; i < SC_DefinedVariables.maxSlots; i++)
        {
            if (i > 7)
                do
                {
                    state = (SC_GlobalEnums.Fruits)Random.Range(1, 8);
                } while (state == SC_DefinedVariables.Slot_values[i - 1] || state == SC_DefinedVariables.Slot_values[i - 8]);

            else
                do
                {
                    state = (SC_GlobalEnums.Fruits)Random.Range(1, 8);
                } while (state == SC_DefinedVariables.Slot_values[i - 1]);

            SC_DefinedVariables.Slot_values.Add(state);
            SC_DefinedVariables.Empowered_slots.Add(0);
            SC_DefinedVariables.Slots["Slot" + i].GetComponent<SC_Slot>().Change_slot_state(state);
            SC_DefinedVariables.Slots["Slot" + i].GetComponent<SC_Slot>().SlotSelectedImage.enabled = false;
            SC_DefinedVariables.Slots["Slot" + i].GetComponent<SC_Slot>().SlotEmpowerImage.enabled = false;
        }
        SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(3).GetChild(1).GetComponent<Text>().text = SC_DefinedVariables.Score.ToString();
        SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(4).GetChild(1).GetComponent<Text>().text = SC_DefinedVariables.Target.ToString();
        SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(8).GetComponent<Text>().text = SC_DefinedVariables.Level.ToString();
        //if (SC_DefinedVariables.multiplayer == true)
        //   Send_Board_Init(SC_DefinedVariables.Slot_values);

        //SC_DefinedVariables.Slots["Slot24"].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.white);
        
        SC_DefinedVariables.Slots["Slot0"].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.Coconut);
        SC_DefinedVariables.Slots["Slot1"].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.Coconut);
        SC_DefinedVariables.Slots["Slot10"].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.Coconut);
        SC_DefinedVariables.Slots["Slot0"].GetComponent<SC_Slot>().Change_slot_empowerment(2);
        
        /*SC_DefinedVariables.Slots["Slot41"].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.white);
        SC_DefinedVariables.Slots["Slot50"].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.white);
        SC_DefinedVariables.Slots["Slot43"].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.white);
        /* SC_DefinedVariables.Slots["Slot28"].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.white);
         SC_DefinedVariables.Slots["Slot18"].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.white);
         SC_DefinedVariables.Slots["Slot10"].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.white);
         SC_DefinedVariables.Slot_values[10] = SC_GlobalEnums.Fruits.white;
         SC_DefinedVariables.Slot_values[18] = SC_GlobalEnums.Fruits.white;*/
        //SC_DefinedVariables.Slot_values[24] = SC_GlobalEnums.Fruits.white;
        
        SC_DefinedVariables.Slot_values[0] = SC_GlobalEnums.Fruits.Coconut;
        SC_DefinedVariables.Slot_values[1] = SC_GlobalEnums.Fruits.Coconut;
        SC_DefinedVariables.Slot_values[10] = SC_GlobalEnums.Fruits.Coconut;
        SC_DefinedVariables.Empowered_slots[0] = 2;
        
        /*SC_DefinedVariables.Slot_values[41] = SC_GlobalEnums.Fruits.white;
        SC_DefinedVariables.Slot_values[43] = SC_GlobalEnums.Fruits.white;
        SC_DefinedVariables.Slot_values[50] = SC_GlobalEnums.Fruits.white;*/
        //  SC_DefinedVariables.Slot_values[28] = SC_GlobalEnums.Fruits.white; 
    }

    public IEnumerator SwapAnimation(int firstObj, int secondObj)
    {
        if (firstObj == secondObj + 1)
        {
            for (int i = 0; i < 10; i++)
            {
                SC_DefinedVariables.Slots["Slot" + firstObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.x - 17.5f, SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.y);
                SC_DefinedVariables.Slots["Slot" + secondObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.x + 17.5f, SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.y);
                yield return null;
            }
            SC_DefinedVariables.Slots["Slot" + firstObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.x + 175f, SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.y);
            SC_DefinedVariables.Slots["Slot" + secondObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.x - 175f, SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.y);
        }
        else if (firstObj == secondObj - 1)
        {
            for (int i = 0; i < 10; i++)
            {
                SC_DefinedVariables.Slots["Slot" + firstObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.x + 17.5f, SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.y);
                SC_DefinedVariables.Slots["Slot" + secondObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.x - 17.5f, SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.y);
                yield return null;
            }
            SC_DefinedVariables.Slots["Slot" + firstObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.x - 175f, SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.y);
            SC_DefinedVariables.Slots["Slot" + secondObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.x + 175f, SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.y);
        }
        else if (firstObj == secondObj + 8)
        {
            for (int i = 0; i < 10; i++)
            {
                SC_DefinedVariables.Slots["Slot" + firstObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.x, SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.y + 17.5f);
                SC_DefinedVariables.Slots["Slot" + secondObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.x, SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.y - 17.5f);
                yield return null;
            }
            SC_DefinedVariables.Slots["Slot" + firstObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.x, SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.y - 175f);
            SC_DefinedVariables.Slots["Slot" + secondObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.x, SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.y + 175f);
        }
        else if (firstObj == secondObj - 8)
        {
            for (int i = 0; i < 10; i++)
            {
                SC_DefinedVariables.Slots["Slot" + firstObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.x, SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.y - 17.5f);
                SC_DefinedVariables.Slots["Slot" + secondObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.x, SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.y + 17.5f);
                yield return null;
            }
            SC_DefinedVariables.Slots["Slot" + firstObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.x, SC_DefinedVariables.Slots["Slot" + firstObj].transform.position.y + 175f);
            SC_DefinedVariables.Slots["Slot" + secondObj].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.x, SC_DefinedVariables.Slots["Slot" + secondObj].transform.position.y - 175f);
        }

        SwapLogic(firstObj, secondObj);
    }

    private void SwapLogic(int firstObj, int secondObj)
    {
        List<int> ValuesForComboCheck = new List<int>();
        ValuesForComboCheck.Add(firstObj);
        ValuesForComboCheck.Add(secondObj);
        bool wasCombo = false;

        if (SC_DefinedVariables.Slot_values[firstObj] != SC_DefinedVariables.Slot_values[secondObj] && SwapMonstersBack == true)
        {
            SwapValues(firstObj, secondObj);
            wasCombo = ComboCheck(ValuesForComboCheck);
        }
        SC_DefinedVariables.Slots["Slot" + firstObj].GetComponent<SC_Slot>().SlotSelectedImage.enabled = false;
        SC_DefinedVariables.Slots["Slot" + secondObj].GetComponent<SC_Slot>().SlotSelectedImage.enabled = false;

        if (wasCombo == false && SwapMonstersBack == true)
        {
            SC_DefinedVariables.Slots["Slot" + firstObj].GetComponent<SC_Slot>().SlotSelectedImage.enabled = true;
            SC_DefinedVariables.Slots["Slot" + secondObj].GetComponent<SC_Slot>().SlotSelectedImage.enabled = true;
            SwapMonstersBack = false;
            StartCoroutine(SwapAnimation(firstObj, secondObj));
            if (SC_DefinedVariables.Slot_values[firstObj] != SC_DefinedVariables.Slot_values[secondObj])
                SwapValues(firstObj, secondObj);
        }
        else
            SwapMonstersBack = true;
    }

    private void SwapValues(int firstObj, int secondObj)
    {
        SC_GlobalEnums.Fruits temp;
        int tmp;

        temp = SC_DefinedVariables.Slot_values[firstObj];
        SC_DefinedVariables.Slot_values[firstObj] = SC_DefinedVariables.Slot_values[secondObj];
        SC_DefinedVariables.Slot_values[secondObj] = temp;

        tmp = SC_DefinedVariables.Empowered_slots[firstObj];
        SC_DefinedVariables.Empowered_slots[firstObj] = SC_DefinedVariables.Empowered_slots[secondObj];
        SC_DefinedVariables.Empowered_slots[secondObj] = tmp;

        SC_DefinedVariables.Slots["Slot" + firstObj].GetComponent<SC_Slot>().Change_slot_state(SC_DefinedVariables.Slot_values[firstObj]);
        SC_DefinedVariables.Slots["Slot" + secondObj].GetComponent<SC_Slot>().Change_slot_state(SC_DefinedVariables.Slot_values[secondObj]);
        SC_DefinedVariables.Slots["Slot" + firstObj].GetComponent<SC_Slot>().Change_slot_empowerment(SC_DefinedVariables.Empowered_slots[firstObj]);
        SC_DefinedVariables.Slots["Slot" + secondObj].GetComponent<SC_Slot>().Change_slot_empowerment(SC_DefinedVariables.Empowered_slots[secondObj]);
    }

    private bool ComboCheck(List<int> ValuesForComboCheck)
    {
        int ComboSize;
        List<int> SlotsToBomb = new List<int>();
        List<int> SlotsToEmpower = new List<int>();

        foreach (int index in ValuesForComboCheck)
        {
            ComboSize = Check_Combo_Size(index, SlotsToBomb);

            switch (ComboSize) // slots empowered get bombed on next call
            {
                case 2:
                    Create_Level_1_Empowerment(index, SlotsToEmpower, SlotsToBomb);
                    SC_DefinedVariables.Score += 300 * SC_DefinedVariables.Level;
                    break;

                case 3:
                    SC_DefinedVariables.Empowered_slots[index] = 2;
                    Create_Level_2_3_4_Empowerment(index, SlotsToEmpower, SlotsToBomb);
                    SC_DefinedVariables.Score += 750 * SC_DefinedVariables.Level;
                    break;

                case 4:
                    SC_DefinedVariables.Empowered_slots[index] = 3;
                    Create_Level_2_3_4_Empowerment(index, SlotsToEmpower, SlotsToBomb);
                    SC_DefinedVariables.Score += 1250 * SC_DefinedVariables.Level;
                    break;

                case 5:
                    SC_DefinedVariables.Empowered_slots[index] = 4;
                    Create_Level_2_3_4_Empowerment(index, SlotsToEmpower, SlotsToBomb);
                    SC_DefinedVariables.Score += 2000 * SC_DefinedVariables.Level;
                    break;

                default:
                    break;
            }
        }
        ScoreObject.transform.GetChild(1).GetComponent<Text>().text = SC_DefinedVariables.Score.ToString();

        foreach (int i in SlotsToEmpower)
            SC_DefinedVariables.Slots["Slot" + i].GetComponent<SC_Slot>().Change_slot_empowerment(SC_DefinedVariables.Empowered_slots[i]);

        if (SlotsToBomb.Count != 0)
        {
            List<int> EmptyList = new List<int>(); // needed second list for the recursion inside to keep track of bombed indexes from before
            StartCoroutine(BombIndexes(SlotsToBomb, EmptyList));
            return true;
        }
        if (SC_DefinedVariables.Score >= SC_DefinedVariables.Target)
            StartCoroutine(Win(SC_DefinedVariables.Screens["LevelComplete_screen"]));

        else if (SC_DefinedVariables.MyScore > SC_DefinedVariables.Target)
        {
            SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(9).GetChild(7).gameObject.SetActive(true);
            SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(9).GetChild(7).GetChild(0).GetComponent<Text>().text = "YOU WON";
        }
        else if (SC_DefinedVariables.OpScore > SC_DefinedVariables.Target)
        {
            SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(9).GetChild(7).gameObject.SetActive(true);
            SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(9).GetChild(7).GetChild(0).GetComponent<Text>().text = "YOU LOST";
        }

        return false;
    }

    private int Check_Combo_Size(int index, List<int> SlotsToBomb)
    {
        int VerticalCombo = 0;
        int HorizontalCombo = 0;
        int ComboSize;

        VerticalCombo += CheckHorizontal(SlotsToBomb, index, index + 1, index + 2); // from the right
        VerticalCombo += CheckHorizontal(SlotsToBomb, index - 2, index - 1, index); // from the left
        VerticalCombo += CheckHorizontal(SlotsToBomb, index - 1, index, index + 1); // from the middle horizontal
        HorizontalCombo += CheckVertical(SlotsToBomb, index, index + 8, index + 16); // from the bottom
        HorizontalCombo += CheckVertical(SlotsToBomb, index - 16, index - 8, index); // from the top
        HorizontalCombo += CheckVertical(SlotsToBomb, index - 8, index, index + 8); // from the middle vertical
        ComboSize = HorizontalCombo + VerticalCombo;
        if (HorizontalCombo != 0 && VerticalCombo != 0)
            ComboSize++;
        return ComboSize;
    }

    private int CheckHorizontal(List<int> SlotsToBomb, int x, int y, int z)
    {
        if (x >= 0 && x < SC_DefinedVariables.maxSlots && y >= 0 && y < SC_DefinedVariables.maxSlots && z >= 0 && z < SC_DefinedVariables.maxSlots && y % 8 != 0 && z % 8 != 0)
        { // if all in range and the same row
            if (SC_DefinedVariables.Slot_values[x] == SC_DefinedVariables.Slot_values[y] && SC_DefinedVariables.Slot_values[x] == SC_DefinedVariables.Slot_values[z])
            { // if they match
                if (!SlotsToBomb.Contains(x)) SlotsToBomb.Add(x);
                if (!SlotsToBomb.Contains(y)) SlotsToBomb.Add(y);
                if (!SlotsToBomb.Contains(z)) SlotsToBomb.Add(z);
                return 1;
            }
        }
        return 0;
    }

    private int CheckVertical(List<int> SlotsToBomb, int x, int y, int z)
    {
        if (x >= 0 && x < SC_DefinedVariables.maxSlots && y >= 0 && y < SC_DefinedVariables.maxSlots && z >= 0 && z < SC_DefinedVariables.maxSlots)
        { // if all in range
            if (SC_DefinedVariables.Slot_values[x] == SC_DefinedVariables.Slot_values[y] && SC_DefinedVariables.Slot_values[x] == SC_DefinedVariables.Slot_values[z])
            { // if they match
                if (!SlotsToBomb.Contains(x)) SlotsToBomb.Add(x);
                if (!SlotsToBomb.Contains(y)) SlotsToBomb.Add(y);
                if (!SlotsToBomb.Contains(z)) SlotsToBomb.Add(z);
                return 1;
            }
        }
        return 0;
    }

    private void Create_Level_1_Empowerment(int index, List<int> SlotsToEmpower, List<int> PreBombingSlots)
    {
        if (index + 1 % 8 != 0 && SC_DefinedVariables.Empowered_slots[index + 1] >= 1 &&
                       SC_DefinedVariables.Slot_values[index] == SC_DefinedVariables.Slot_values[index + 1] && SlotsToEmpower.Contains(index + 1))
        {
            return;
        }
        if (index % 8 != 0 && SC_DefinedVariables.Empowered_slots[index - 1] >= 1 &&
           SC_DefinedVariables.Slot_values[index] == SC_DefinedVariables.Slot_values[index - 1] && SlotsToEmpower.Contains(index - 1))
        {
            return;
        }
        if (index + 8 < SC_DefinedVariables.maxSlots && SC_DefinedVariables.Empowered_slots[index + 8] >= 1 &&
           SC_DefinedVariables.Slot_values[index] == SC_DefinedVariables.Slot_values[index + 8] && SlotsToEmpower.Contains(index + 8))
        {
            return;
        }
        if (index - 8 >= 0 && SC_DefinedVariables.Empowered_slots[index - 8] >= 1 &&
           SC_DefinedVariables.Slot_values[index] == SC_DefinedVariables.Slot_values[index - 8] && SlotsToEmpower.Contains(index - 8))
        {
            return;
        }
        SlotsToEmpower.Add(index);
        PreBombingSlots.Remove(index);
        SC_DefinedVariables.Empowered_slots[index] = 1;
    }

    private void Create_Level_2_3_4_Empowerment(int index, List<int> SlotsToEmpower, List<int> PreBombingSlots)
    {
        SlotsToEmpower.Add(index);
        PreBombingSlots.Remove(index);

        if (index + 1 % 8 != 0 && SC_DefinedVariables.Empowered_slots[index + 1] == 1 &&
           SC_DefinedVariables.Slot_values[index] == SC_DefinedVariables.Slot_values[index + 1] && SlotsToEmpower.Contains(index + 1))
        {
            SlotsToEmpower.Remove(index + 1);
            PreBombingSlots.Add(index + 1);
            SC_DefinedVariables.Empowered_slots[index + 1] = 0;
        }
        if (index % 8 != 0 && SC_DefinedVariables.Empowered_slots[index - 1] == 1 &&
           SC_DefinedVariables.Slot_values[index] == SC_DefinedVariables.Slot_values[index - 1] && SlotsToEmpower.Contains(index - 1))
        {
            SlotsToEmpower.Remove(index - 1);
            PreBombingSlots.Add(index - 1);
            SC_DefinedVariables.Empowered_slots[index - 1] = 0;
        }
        if (index + 8 < SC_DefinedVariables.maxSlots && SC_DefinedVariables.Empowered_slots[index + 8] == 1 &&
           SC_DefinedVariables.Slot_values[index] == SC_DefinedVariables.Slot_values[index + 8] && SlotsToEmpower.Contains(index + 8))
        {
            SlotsToEmpower.Remove(index + 8);
            PreBombingSlots.Add(index + 8);
            SC_DefinedVariables.Empowered_slots[index + 8] = 0;
        }
        if (index - 8 >= 0 && SC_DefinedVariables.Empowered_slots[index - 8] == 1 &&
           SC_DefinedVariables.Slot_values[index] == SC_DefinedVariables.Slot_values[index - 8] && SlotsToEmpower.Contains(index - 8))
        {
            SlotsToEmpower.Remove(index - 8);
            PreBombingSlots.Add(index - 8);
            SC_DefinedVariables.Empowered_slots[index - 8] = 0;
        }
    }

    private IEnumerator BombIndexes(List<int> SlotsToBomb, List<int> Older_Bombed_Indexes)
    {
        List<int> Additional_Slots_To_Bomb = new List<int>();

        Empowerment_activation(Additional_Slots_To_Bomb, SlotsToBomb); // check if there were special slots in the bombing values

        Boom.Play();
        for (int i = 0; i < 3; i++) // bombing animation
        {
            foreach (int index in SlotsToBomb)
            {
                if (i == 0)
                    SC_DefinedVariables.Slots["Slot" + index].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.boom1);
                if (i == 1)
                    SC_DefinedVariables.Slots["Slot" + index].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.boom2);
                if (i == 2)
                    SC_DefinedVariables.Slots["Slot" + index].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.boom3);
                yield return null;
            }
        }

        foreach (int index in SlotsToBomb) // empty status
        {
            SC_DefinedVariables.Slots["Slot" + index].GetComponent<SC_Slot>().Change_slot_state(SC_GlobalEnums.Fruits.empty);
            SC_DefinedVariables.Slot_values[index] = SC_GlobalEnums.Fruits.empty;
            SC_DefinedVariables.Empowered_slots[index] = 0;
            if (SC_DefinedVariables.multiplayer == false)
                SC_DefinedVariables.Score += 50 * SC_DefinedVariables.Level;
            else
            {
                if (SC_DefinedVariables.IsMyTurn == true)
                    SC_DefinedVariables.MyScore += 50 * SC_DefinedVariables.Level;
                else
                    SC_DefinedVariables.OpScore += 50 * SC_DefinedVariables.Level;
            }
        }
        if (SC_DefinedVariables.multiplayer == false)
            SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(3).GetChild(1).GetComponent<Text>().text = SC_DefinedVariables.Score.ToString();
        else
        {
            if (SC_DefinedVariables.IsMyTurn == true)
                SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(9).GetChild(4).GetComponent<Text>().text = SC_DefinedVariables.MyScore.ToString();
            else
                SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(9).GetChild(6).GetComponent<Text>().text = SC_DefinedVariables.OpScore.ToString();
        }

        foreach (int index in SlotsToBomb) // combine older bombed indexes with newer ones for correction later
            if (!Older_Bombed_Indexes.Contains(index))
                Older_Bombed_Indexes.Add(index);

        if (Additional_Slots_To_Bomb.Count > 0) // check if there were new slots bombed           
            StartCoroutine(BombIndexes(Additional_Slots_To_Bomb, Older_Bombed_Indexes)); // bomb them too

        else
            CorrectBoard(Older_Bombed_Indexes);
    }

    private void Empowerment_activation(List<int> Additional_Slots_To_Bomb, List<int> Bombed_Slots)
    {
        List<int> Empowered_Slots_Found = new List<int>();

        foreach (int index in Bombed_Slots)
        {
            switch (SC_DefinedVariables.Empowered_slots[index])
            {
                case 0:
                    break;

                case 1: // Bomb around the slot

                    Empowered_Slots_Found.Add(index);
                    Empowerment_Level_1_activation(index, Bombed_Slots, Additional_Slots_To_Bomb);
                    break;

                case 2: // bomb "+" shape the whole board
                    Empowered_Slots_Found.Add(index);
                    Empowerment_Level_2_activation(index, Bombed_Slots, Additional_Slots_To_Bomb);
                    break;

                case 3: // bomb "+" and "x" shape the whole board
                    Empowered_Slots_Found.Add(index);
                    Empowerment_Level_3_activation(index, Bombed_Slots, Additional_Slots_To_Bomb);
                    break;

                case 4: // bomb "+" shape the whole board with 3 rows and columns and "x" shape
                    Empowered_Slots_Found.Add(index);
                    Empowerment_Level_4_activation(index, Bombed_Slots, Additional_Slots_To_Bomb);
                    break;
            }
        }
        if (Empowered_Slots_Found.Count > 0)
            foreach (int i in Empowered_Slots_Found)
            {
                Bombed_Slots.Remove(i);
                SC_DefinedVariables.Empowered_slots[i] = 0;
            }
    }

    private void Empowerment_Level_1_activation(int index, List<int> Bombed_Slots, List<int> Additional_Slots_To_Bomb)
    {
        if (!Additional_Slots_To_Bomb.Contains(index))
            Additional_Slots_To_Bomb.Add(index);
        if (index - 9 >= 0 && index % 8 != 0 && !Bombed_Slots.Contains(index - 9) && !Additional_Slots_To_Bomb.Contains(index - 9))
            Additional_Slots_To_Bomb.Add(index - 9);
        if (index - 8 >= 0 && !Bombed_Slots.Contains(index - 8) && !Additional_Slots_To_Bomb.Contains(index - 8))
            Additional_Slots_To_Bomb.Add(index - 8);
        if (index - 7 >= 0 && (index - 7) % 8 != 0 && !Bombed_Slots.Contains(index - 7) && !Additional_Slots_To_Bomb.Contains(index - 7))
            Additional_Slots_To_Bomb.Add(index - 7);
        if (index - 1 >= 0 && index % 8 != 0 && !Bombed_Slots.Contains(index - 1) && !Additional_Slots_To_Bomb.Contains(index - 1))
            Additional_Slots_To_Bomb.Add(index - 1);
        if (index + 1 <= SC_DefinedVariables.maxSlots && (index + 1) % 8 != 0 && !Bombed_Slots.Contains(index + 1) && !Additional_Slots_To_Bomb.Contains(index + 1))
            Additional_Slots_To_Bomb.Add(index + 1);
        if (index + 7 <= SC_DefinedVariables.maxSlots && index % 8 != 0 && !Bombed_Slots.Contains(index + 7) && !Additional_Slots_To_Bomb.Contains(index + 7))
            Additional_Slots_To_Bomb.Add(index + 7);
        if (index + 8 <= SC_DefinedVariables.maxSlots && !Bombed_Slots.Contains(index + 8) && !Additional_Slots_To_Bomb.Contains(index + 8))
            Additional_Slots_To_Bomb.Add(index + 8);
        if (index + 9 <= SC_DefinedVariables.maxSlots && (index + 9) % 8 != 0 && !Bombed_Slots.Contains(index + 9) && !Additional_Slots_To_Bomb.Contains(index + 9))
            Additional_Slots_To_Bomb.Add(index + 9);

        //StartCoroutine(SC_DefinedVariables.Empowerments["Level1Emp"].transform.GetChild(index).GetComponent<SC_Empowerments>().Level_1_Emp_Animation());
    }

    private void Empowerment_Level_2_activation(int index, List<int> Bombed_Slots, List<int> Additional_Slots_To_Bomb)
    {
        if (!Additional_Slots_To_Bomb.Contains(index))
            Additional_Slots_To_Bomb.Add(index);
        for (int i = index - 8; i > 0; i -= 8) //top
            if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                Additional_Slots_To_Bomb.Add(i);
        for (int i = index + 8; i < SC_DefinedVariables.maxSlots; i += 8) // bottom
            if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                Additional_Slots_To_Bomb.Add(i);
        for (int i = index - 1; i > 0 && (i + 1) % 8 != 0; i--) // left
            if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                Additional_Slots_To_Bomb.Add(i);
        for (int i = index + 1; i < SC_DefinedVariables.maxSlots && i % 8 != 0; i++) // right
            if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                Additional_Slots_To_Bomb.Add(i);

        SC_DefinedVariables.Empowerments.transform.GetChild(index).GetComponent<SC_Empowerments>().Level_2_Emp_Animation(index);
    }

    private void Empowerment_Level_3_activation(int index, List<int> Bombed_Slots, List<int> Additional_Slots_To_Bomb)
    {
        Empowerment_Level_2_activation(index, Bombed_Slots, Additional_Slots_To_Bomb);

        for (int i = index - 9; i >= 0 && (i + 9) % 8 != 0; i -= 9) // left top
            if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                Additional_Slots_To_Bomb.Add(i);
        for (int i = index - 7; i > 0 && i % 8 != 0; i -= 7) // right top
            if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                Additional_Slots_To_Bomb.Add(i);
        for (int i = index + 7; i < SC_DefinedVariables.maxSlots && (i - 7) % 8 != 0; i += 7) // left bottom
            if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                Additional_Slots_To_Bomb.Add(i);
        for (int i = index + 9; i < SC_DefinedVariables.maxSlots && i % 8 != 0; i += 9) // right bottom
            if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                Additional_Slots_To_Bomb.Add(i);

        SC_DefinedVariables.Empowerments.transform.GetChild(index).GetComponent<SC_Empowerments>().Level_3_Emp_Animation(index);
    }

    private void Empowerment_Level_4_activation(int index, List<int> Bombed_Slots, List<int> Additional_Slots_To_Bomb)
    {
        Empowerment_Level_2_activation(index, Bombed_Slots, Additional_Slots_To_Bomb);

        if (index % 8 != 0) // left top 
            for (int i = index - 9; i > 0; i -= 8)
                if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                    Additional_Slots_To_Bomb.Add(i);
        if ((index + 1) % 8 != 0) // right top 
            for (int i = index - 7; i > 0; i -= 8)
                if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                    Additional_Slots_To_Bomb.Add(i);
        if (index % 8 != 0) // left bottom
            for (int i = index + 7; i < SC_DefinedVariables.maxSlots; i += 8)
                if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                    Additional_Slots_To_Bomb.Add(i);
        if ((index + 1) % 8 != 0) // right bottom
            for (int i = index + 9; i < SC_DefinedVariables.maxSlots; i += 8)
                if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                    Additional_Slots_To_Bomb.Add(i);
        if (index > 9) // top left
            for (int i = index - 10; (i + 1) % 8 != 0; i--)
                if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                    Additional_Slots_To_Bomb.Add(i);
        if (index < 56) // bottom left
            for (int i = index + 6; (i + 1) % 8 != 0; i--)
                if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                    Additional_Slots_To_Bomb.Add(i);
        if (index > 7) // top right
            for (int i = index - 6; i % 8 != 0; i++)
                if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                    Additional_Slots_To_Bomb.Add(i);
        if (index < 54) // bottom right
            for (int i = index + 10; (i + 1) % 8 != 0; i++)
                if (!Additional_Slots_To_Bomb.Contains(i) && !Bombed_Slots.Contains(i))
                    Additional_Slots_To_Bomb.Add(i);

        SC_DefinedVariables.Empowerments.transform.GetChild(index).GetComponent<SC_Empowerments>().Level_4_Emp_Animation(index);
    }

    private void CorrectBoard(List<int> EffectedSlots)
    {
        List<int> SlotsToFall = new List<int>();
        List<int> HowMuchToFall = new List<int>();

        Logical_Board_Correction(EffectedSlots, SlotsToFall, HowMuchToFall);
        StartCoroutine(Visual_Board_Correction(EffectedSlots, SlotsToFall, HowMuchToFall));
    }

    private void Logical_Board_Correction(List<int> EffectedSlots, List<int> SlotsToFall, List<int> HowMuchToFall)
    {
        EffectedSlots.Sort();
        EffectedSlots.Reverse();

        for (int index = 0; index < EffectedSlots.Count; index++)
        {
            if (SC_DefinedVariables.Slot_values[EffectedSlots[index]] == SC_GlobalEnums.Fruits.empty)
            {
                for (int i = EffectedSlots[index] - 8; i >= 0 && SC_DefinedVariables.Slot_values[EffectedSlots[index]] == SC_GlobalEnums.Fruits.empty; i -= 8) // run through slots above
                {
                    if (SC_DefinedVariables.Slot_values[i] != SC_GlobalEnums.Fruits.empty) // if slot above not empty move it down
                    {
                        SC_DefinedVariables.Slot_values[EffectedSlots[index]] = SC_DefinedVariables.Slot_values[i];
                        SC_DefinedVariables.Slot_values[i] = SC_GlobalEnums.Fruits.empty;
                        SC_DefinedVariables.Empowered_slots[EffectedSlots[index]] = SC_DefinedVariables.Empowered_slots[i];
                        SC_DefinedVariables.Empowered_slots[i] = 0;
                        SlotsToFall.Add(i);
                        HowMuchToFall.Add((EffectedSlots[index] - i) / 8);
                        if (!EffectedSlots.Contains(i)) EffectedSlots.Add(i);
                        break;
                    }

                    if (!EffectedSlots.Contains(i)) EffectedSlots.Add(i);
                }
            }
        }
    }

    private IEnumerator Visual_Board_Correction(List<int> EffectedSlots, List<int> SlotsToFall, List<int> HowMuchToFall)
    {
        int maxValue = 0;

        foreach (int index in HowMuchToFall)
            if (index > maxValue) maxValue = index;


        for (int i = 0; i < maxValue * 7; i++)
        {
            for (int index = 0; index < SlotsToFall.Count; index++)
            {
                if (i / 7 < HowMuchToFall[index])
                    SC_DefinedVariables.Slots["Slot" + SlotsToFall[index]].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + SlotsToFall[index]].transform.position.x, SC_DefinedVariables.Slots["Slot" + SlotsToFall[index]].transform.position.y - 25f);
            }
            yield return null;
        }

        for (int i = 0; i < SlotsToFall.Count; i++)
            SC_DefinedVariables.Slots["Slot" + SlotsToFall[i]].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + SlotsToFall[i]].transform.position.x, SC_DefinedVariables.Slots["Slot" + SlotsToFall[i]].transform.position.y + 175f * HowMuchToFall[i]);

        foreach (int index in EffectedSlots)
        {
            SC_DefinedVariables.Slots["Slot" + index].GetComponent<SC_Slot>().Change_slot_state(SC_DefinedVariables.Slot_values[index]);
            SC_DefinedVariables.Slots["Slot" + index].GetComponent<SC_Slot>().Change_slot_empowerment(SC_DefinedVariables.Empowered_slots[index]);
        }

        FillGaps(EffectedSlots);
    }

    private void FillGaps(List<int> EffectedSlots)
    {
        int Gap_Depth = 0;
        List<int> Gaps = new List<int>();

        foreach (int index in EffectedSlots)
            if (SC_DefinedVariables.Slot_values[index] == SC_GlobalEnums.Fruits.empty)
                Gaps.Add(index);

        foreach (int index in Gaps)
            if (index > Gap_Depth) Gap_Depth = index;

        StartCoroutine(Fill_Gaps_Animation(Gaps, Gap_Depth, EffectedSlots));
    }

    private IEnumerator Fill_Gaps_Animation(List<int> Gaps, int Gap_Depth, List<int> EffectedSlots)
    {
        SC_GlobalEnums.Fruits state;

        foreach (int index in Gaps)
            SC_DefinedVariables.Slots["Slot" + index].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + index].transform.position.x, SC_DefinedVariables.Slots["Slot" + index].transform.position.y + 175f * (Gap_Depth / 8 + 1));

        if (SC_DefinedVariables.multiplayer == false)
        {
            for (int i = 0; i < Gaps.Count; i++)
            {
                state = (SC_GlobalEnums.Fruits)Random.Range(1, 8);
                SC_DefinedVariables.Slot_values[Gaps[i]] = state;
                SC_DefinedVariables.Slots["Slot" + Gaps[i]].GetComponent<SC_Slot>().Change_slot_state(state);
            }
        }
        else
        {
            Gaps.Sort();
            for (int i = 0; i < Gaps.Count; i++)
            {
                state = (SC_GlobalEnums.Fruits)SC_DefinedVariables.Gap_Filling_Values[SC_DefinedVariables.Gap_Filling_Counter];
                SC_DefinedVariables.Gap_Filling_Counter++;
                SC_DefinedVariables.Slot_values[Gaps[i]] = state;
                SC_DefinedVariables.Slots["Slot" + Gaps[i]].GetComponent<SC_Slot>().Change_slot_state(state);
            }
        }

        for (int i = 0; i < (Gap_Depth / 8 + 1) * 7; i++)
        {
            foreach (int index in Gaps)
                SC_DefinedVariables.Slots["Slot" + index].transform.position = new Vector2(SC_DefinedVariables.Slots["Slot" + index].transform.position.x, SC_DefinedVariables.Slots["Slot" + index].transform.position.y - 25f);

            yield return null;
        }
        ComboCheck(EffectedSlots);
    }

    /*private IEnumerator Add_To_Score(int points)
    {

    }*/

    private IEnumerator Win(GameObject Level_Complete_Screen)
    {
        float tempTarget = SC_DefinedVariables.Target / 1000;

        Level_Complete_Screen.SetActive(true);

        for (int i = 0; i < 50; i++)
        {
            Level_Complete_Screen.transform.GetChild(1).transform.position = new Vector2(Level_Complete_Screen.transform.GetChild(1).transform.position.x, Level_Complete_Screen.transform.GetChild(1).transform.position.y - 30);
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        Level_Complete_Screen.transform.GetChild(1).transform.position = new Vector2(Level_Complete_Screen.transform.GetChild(1).transform.position.x, Level_Complete_Screen.transform.GetChild(1).transform.position.y + 1500);
        StartCoroutine(SC_Buttons.Instance.Loading_Singleplayer(SC_DefinedVariables.Screens["Loading_screen"]));
        yield return new WaitForSeconds(2f);
        Level_Complete_Screen.SetActive(false);
        SC_DefinedVariables.Level++;
        tempTarget *= 2500;
        SC_DefinedVariables.Target = (int)tempTarget;
        InitBoard();
    }

    //MULTIPLAYER

    private void OnEnable()
    {
        Listener.OnGameStarted += OnGameStarted;
        Listener.OnMoveCompleted += OnMoveCompleted;
        Listener.OnChatSent += OnChatSent;
    }

    private void OnDisable()
    {
        Listener.OnGameStarted -= OnGameStarted;
        Listener.OnMoveCompleted -= OnMoveCompleted;
        Listener.OnChatSent -= OnChatSent;
    }

    public void Send_Move(int index1, int index2)
    {
        SC_DefinedVariables.IsMyTurn = false;
        Dictionary<string, object> toSend = new Dictionary<string, object>();
        toSend.Add("UserName", SC_DefinedVariables.userName);
        toSend.Add("Value1", index1);
        toSend.Add("Value2", index2);
        string jsonToSend = MiniJSON.Json.Serialize(toSend);
        WarpClient.GetInstance().sendMove(jsonToSend);
    }

    public void Send_Board_Init(List<SC_GlobalEnums.Fruits> Board)
    {
        Dictionary<string, object> toSend = new Dictionary<string, object>();
        toSend.Add("UserName", SC_DefinedVariables.userName);
        for (int i = 0; i < SC_DefinedVariables.maxSlots; i++)
            toSend.Add("Slot" + i, (int)Board[i]);

        string jsonToSend = MiniJSON.Json.Serialize(toSend);
        WarpClient.GetInstance().SendChat(jsonToSend);
    }

    public void Send_Gap_Filling()
    {
        Dictionary<string, object> toSend = new Dictionary<string, object>();
        SC_DefinedVariables.Gap_Filling_Values = new List<int>();
        for (int i = 0; i < 100; i++)
        {
            SC_DefinedVariables.Gap_Filling_Values.Add(Random.Range(1, 8));
            toSend.Add("Gap" + i, SC_DefinedVariables.Gap_Filling_Values[i]);
        }
        string jsonToSend = MiniJSON.Json.Serialize(toSend);
        WarpClient.GetInstance().SendChat(jsonToSend);
    }

    public void OnMoveCompleted(MoveEvent Move)
    {
        Debug.Log("OnMoveCompleted " + Move.getMoveData() + "" + Move.getNextTurn());
        if (Move.getSender() != SC_DefinedVariables.userName)
        {
            if (Move.getMoveData() != null)
            {
                Dictionary<string, object> receivedData = MiniJSON.Json.Deserialize(Move.getMoveData()) as Dictionary<string, object>;
                int index1 = int.Parse(receivedData["Value1"].ToString());
                int index2 = int.Parse(receivedData["Value2"].ToString());
                StartCoroutine(SwapAnimation(index1, index2));
                if (Move.getNextTurn() == SC_DefinedVariables.userName)
                    SC_DefinedVariables.IsMyTurn = true;
                else SC_DefinedVariables.IsMyTurn = false;
            }
        }
    }

    public void OnChatSent(ChatEvent Chat)
    {
        if (Chat.getSender() != SC_DefinedVariables.userName)
        {
            if (Chat.getMessage() != null)
            {
                Dictionary<string, object> receivedData = MiniJSON.Json.Deserialize(Chat.getMessage()) as Dictionary<string, object>;

                if (receivedData != null)
                {
                    if (SC_DefinedVariables.Slot_values == null)
                    {
                        SC_GlobalEnums.Fruits state;
                        SC_DefinedVariables.Slot_values = new List<SC_GlobalEnums.Fruits>();
                        SC_DefinedVariables.Empowered_slots = new List<int>();
                        int val;
                        for (int i = 0; i < SC_DefinedVariables.maxSlots; i++)
                        {
                            val = int.Parse(receivedData["Slot" + i].ToString());
                            state = (SC_GlobalEnums.Fruits)val;
                            SC_DefinedVariables.Slot_values.Add(state);
                            SC_DefinedVariables.Empowered_slots.Add(0);
                            SC_DefinedVariables.Slots["Slot" + i].GetComponent<SC_Slot>().Change_slot_state(state);
                            SC_DefinedVariables.Slots["Slot" + i].GetComponent<SC_Slot>().SlotSelectedImage.enabled = false;
                            SC_DefinedVariables.Slots["Slot" + i].GetComponent<SC_Slot>().SlotEmpowerImage.enabled = false;
                        }
                    }
                    else
                    {
                        SC_DefinedVariables.Gap_Filling_Values = new List<int>();
                        for (int i = 0; i < 100; i++)
                        {
                            SC_DefinedVariables.Gap_Filling_Values.Add(int.Parse(receivedData["Gap" + i].ToString()));
                        }
                    }
                }
            }
            else WarpClient.GetInstance().stopGame();
        }
    }

    public void OnGameStarted(string _Sender, string _RoomId, string _NextTurn)
    {
        SC_DefinedVariables.multiplayer = true;

        if (SC_DefinedVariables.IsMyTurn == true)
        {
            InitBoard();
            Send_Board_Init(SC_DefinedVariables.Slot_values);
            Send_Gap_Filling();
        }
        StartCoroutine(Start_Multiplayer_Game(SC_DefinedVariables.Screens["Loading_screen"]));
        Debug.Log("OnGameStarted");

    }

    private IEnumerator Start_Multiplayer_Game(GameObject LoadingScreen)
    {

        Color LoadingTxt = LoadingScreen.transform.GetChild(3).GetComponent<Image>().color;
        Color WhiteBackground = LoadingScreen.transform.GetChild(0).GetComponent<Image>().color;
        LoadingScreen.transform.GetChild(8).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(10).gameObject.SetActive(false);
        SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(9).GetChild(2).GetComponent<Text>().text = SC_DefinedVariables.Target.ToString();
        SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(9).GetChild(7).gameObject.SetActive(false);
        SC_DefinedVariables.Screens["Login_screen"].SetActive(false);

        for (int i = 3; i < 7; i++)
        {
            LoadingScreen.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            LoadingScreen.transform.GetChild(i).gameObject.SetActive(false);
        }
        SC_DefinedVariables.Screens["Menu_screen"].SetActive(false);
        SC_DefinedVariables.Screens["Gameplay_screen"].SetActive(true);

        for (int i = 0; i < 33; i++)
        {
            LoadingScreen.transform.GetChild(1).position = new Vector2(LoadingScreen.transform.GetChild(1).position.x + 35, LoadingScreen.transform.GetChild(1).position.y);
            LoadingScreen.transform.GetChild(2).position = new Vector2(LoadingScreen.transform.GetChild(2).position.x - 35, LoadingScreen.transform.GetChild(2).position.y);
            LoadingTxt.a -= 0.03f;
            WhiteBackground.a -= 0.03f;
            LoadingScreen.transform.GetChild(3).GetComponent<Image>().color = LoadingTxt;
            LoadingScreen.transform.GetChild(0).GetComponent<Image>().color = WhiteBackground;
            yield return null;
        }
        LoadingScreen.SetActive(false);
    }

}