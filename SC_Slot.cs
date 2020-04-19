using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Slot : MonoBehaviour
{
    public Sprite Cherry, Banana, Kiwi, Raspberry, Coconut, Watermelon, Orange, boom1, boom2, boom3, SlotEmpower1, SlotEmpower2, SlotEmpower3, SlotEmpower4;
    public Image SlotImage, SlotSelectedImage, SlotEmpowerImage;
    private static bool MonsterAlreadySelected = false;
    public static int selected1index, selected2index;

    public void Change_slot_state(SC_GlobalEnums.Fruits state)
    {

        if (SlotImage != null)
        {
            if (state == SC_GlobalEnums.Fruits.empty)
                SlotImage.enabled = false;

            else
            {
                switch (state)
                {
                    case SC_GlobalEnums.Fruits.Cherry:
                        SlotImage.sprite = Cherry;
                        break;

                    case SC_GlobalEnums.Fruits.Banana:
                        SlotImage.sprite = Banana;
                        break;

                    case SC_GlobalEnums.Fruits.Orange:
                        SlotImage.sprite = Orange;
                        break;

                    case SC_GlobalEnums.Fruits.Coconut:
                        SlotImage.sprite = Coconut;
                        break;

                    case SC_GlobalEnums.Fruits.Watermelon:
                        SlotImage.sprite = Watermelon;
                        break;

                    case SC_GlobalEnums.Fruits.Raspberry:
                        SlotImage.sprite = Raspberry;
                        break;

                    case SC_GlobalEnums.Fruits.Kiwi:
                        SlotImage.sprite = Kiwi;
                        break;

                    case SC_GlobalEnums.Fruits.boom1:
                        SlotImage.sprite = boom1;
                        break;

                    case SC_GlobalEnums.Fruits.boom2:
                        SlotImage.sprite = boom2;
                        break;

                    case SC_GlobalEnums.Fruits.boom3:
                        SlotImage.sprite = boom3;
                        break;
                }
                SlotImage.enabled = true;
            }
        }
    }

    public void SlotClicked(int index)
    { 
        if (SC_DefinedVariables.multiplayer == false || (SC_DefinedVariables.multiplayer == true && SC_DefinedVariables.IsMyTurn == true))
        {
            if (MonsterAlreadySelected == false)
            {
                MonsterAlreadySelected = true;
                selected1index = index;
                SC_DefinedVariables.Slots["Slot" + selected1index].GetComponent<SC_Slot>().SlotSelectedImage.enabled = true;
            }
            else
            {
                if (index == selected1index)
                {
                    MonsterAlreadySelected = false;
                    SC_DefinedVariables.Slots["Slot" + selected1index].GetComponent<SC_Slot>().SlotSelectedImage.enabled = false;
                }
                else if (index == selected1index - 8 || index == selected1index + 8 ||   //check if the second object
                    (index == selected1index - 1 && selected1index % 8 != 0) ||         //is above, under or 
                    (index == selected1index + 1 && index % 8 != 0))                    //aside on the same row
                { //if yes than swap
                    selected2index = index;
                    SC_DefinedVariables.Slots["Slot" + selected2index].GetComponent<SC_Slot>().SlotSelectedImage.enabled = true;

                    if (SC_DefinedVariables.multiplayer == true)
                        SC_Logic.Instance.Send_Move(selected1index, selected2index);

                    StartCoroutine(SC_Logic.Instance.SwapAnimation(selected1index, selected2index));
                    MonsterAlreadySelected = false;
                }
                else //uncheck the first object and make another one as first
                {
                    SC_DefinedVariables.Slots["Slot" + selected1index].GetComponent<SC_Slot>().SlotSelectedImage.enabled = false;
                    selected1index = index;
                    SC_DefinedVariables.Slots["Slot" + selected1index].GetComponent<SC_Slot>().SlotSelectedImage.enabled = true;
                }
            }
        }
    }

    public void Change_slot_empowerment(int type)
    {
        if (type == 0)
            SlotEmpowerImage.enabled = false;

        else
        {
            SlotEmpowerImage.enabled = true;

            if (type == 1)
                SlotEmpowerImage.sprite = SlotEmpower1;
            else if (type == 2)
                SlotEmpowerImage.sprite = SlotEmpower2;
            else if (type == 3)
                SlotEmpowerImage.sprite = SlotEmpower3;
            else if (type == 4)
                SlotEmpowerImage.sprite = SlotEmpower4;
        }
    }

}