using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Empowerments : MonoBehaviour
{
    public Image EmpImage;

    //Level 2 empowerment sprites
    public Sprite E2P1Banana, E2P2Banana, E2P3Banana, E2P4Banana, E2P5Banana;
    public Sprite E2P1Cherry, E2P2Cherry, E2P3Cherry, E2P4Cherry, E2P5Cherry;
    public Sprite E2P1Watermelon, E2P2Watermelon, E2P3Watermelon, E2P4Watermelon, E2P5Watermelon;
    public Sprite E2P1Coconut, E2P2Coconut, E2P3Coconut, E2P4Coconut, E2P5Coconut;
    public Sprite E2P1Kiwi, E2P2Kiwi, E2P3Kiwi, E2P4Kiwi, E2P5Kiwi;
    public Sprite E2P1Orange, E2P2Orange, E2P3Orange, E2P4Orange, E2P5Orange;
    public Sprite E2P1Raspberry, E2P2Raspberry, E2P3Raspberry, E2P4Raspberry, E2P5Raspberry;
    //Level 3 empowerment sprites
    public Sprite E3P1Banana, E3P2Banana, E3P3Banana, E3P4Banana, E3P5Banana;
    public Sprite E3P1Cherry, E3P2Cherry, E3P3Cherry, E3P4Cherry, E3P5Cherry;
    public Sprite E3P1Watermelon, E3P2Watermelon, E3P3Watermelon, E3P4Watermelon, E3P5Watermelon;
    public Sprite E3P1Coconut, E3P2Coconut, E3P3Coconut, E3P4Coconut, E3P5Coconut;
    public Sprite E3P1Kiwi, E3P2Kiwi, E3P3Kiwi, E3P4Kiwi, E3P5Kiwi;
    public Sprite E3P1Orange, E3P2Orange, E3P3Orange, E3P4Orange, E3P5Orange;
    public Sprite E3P1Raspberry, E3P2Raspberry, E3P3Raspberry, E3P4Raspberry, E3P5Raspberry;
    //Level 4 empowerment sprites
    public Sprite E4P1Banana, E4P2Banana, E4P3Banana, E4P4Banana, E4P5Banana;
    public Sprite E4P1Cherry, E4P2Cherry, E4P3Cherry, E4P4Cherry, E4P5Cherry;
    public Sprite E4P1Watermelon, E4P2Watermelon, E4P3Watermelon, E4P4Watermelon, E4P5Watermelon;
    public Sprite E4P1Coconut, E4P2Coconut, E4P3Coconut, E4P4Coconut, E4P5Coconut;
    public Sprite E4P1Kiwi, E4P2Kiwi, E4P3Kiwi, E4P4Kiwi, E4P5Kiwi;
    public Sprite E4P1Orange, E4P2Orange, E4P3Orange, E4P4Orange, E4P5Orange;
    public Sprite E4P1Raspberry, E4P2Raspberry, E4P3Raspberry, E4P4Raspberry, E4P5Raspberry;

    public void Level_2_Emp_Animation(int index)
    {
        if (EmpImage != null)
        {
            switch (SC_DefinedVariables.Slot_values[index])
            {
                case SC_GlobalEnums.Fruits.Cherry:
                    StartCoroutine(Level_2_Cherry());
                    break;

                case SC_GlobalEnums.Fruits.Banana:
                    StartCoroutine(Level_2_Banana());
                    break;

                case SC_GlobalEnums.Fruits.Kiwi:
                    StartCoroutine(Level_2_Kiwi());
                    break;

                case SC_GlobalEnums.Fruits.Raspberry:
                    StartCoroutine(Level_2_Raspberry());
                    break;

                case SC_GlobalEnums.Fruits.Coconut:
                    StartCoroutine(Level_2_Coconut());
                    break;

                case SC_GlobalEnums.Fruits.Watermelon:
                    StartCoroutine(Level_2_Watermelon());
                    break;

                case SC_GlobalEnums.Fruits.Orange:
                    StartCoroutine(Level_2_Orange());
                    break;

                default:
                    break;
            }
        }
    }

    private IEnumerator Level_2_Cherry()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E2P1Cherry;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E2P2Cherry;
                    break;

                case 3:
                    EmpImage.sprite = E2P3Cherry;
                    break;

                case 4:
                    EmpImage.sprite = E2P4Cherry;
                    break;

                case 5:
                    EmpImage.sprite = E2P5Cherry;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_2_Banana()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E2P1Banana;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E2P2Banana;
                    break;

                case 3:
                    EmpImage.sprite = E2P3Banana;
                    break;

                case 4:
                    EmpImage.sprite = E2P4Banana;
                    break;

                case 5:
                    EmpImage.sprite = E2P5Banana;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_2_Kiwi()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E2P1Kiwi;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E2P2Kiwi;
                    break;

                case 3:
                    EmpImage.sprite = E2P3Kiwi;
                    break;

                case 4:
                    EmpImage.sprite = E2P4Kiwi;
                    break;

                case 5:
                    EmpImage.sprite = E2P5Kiwi;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_2_Raspberry()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E2P1Raspberry;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E2P2Raspberry;
                    break;

                case 3:
                    EmpImage.sprite = E2P3Raspberry;
                    break;

                case 4:
                    EmpImage.sprite = E2P4Raspberry;
                    break;

                case 5:
                    EmpImage.sprite = E2P5Raspberry;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_2_Coconut()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E2P1Coconut;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E2P2Coconut;
                    break;

                case 3:
                    EmpImage.sprite = E2P3Coconut;
                    break;

                case 4:
                    EmpImage.sprite = E2P4Coconut;
                    break;

                case 5:
                    EmpImage.sprite = E2P5Coconut;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_2_Watermelon()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E2P1Watermelon;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E2P2Watermelon;
                    break;

                case 3:
                    EmpImage.sprite = E2P3Watermelon;
                    break;

                case 4:
                    EmpImage.sprite = E2P4Watermelon;
                    break;

                case 5:
                    EmpImage.sprite = E2P5Watermelon;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_2_Orange()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E2P1Orange;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E2P2Orange;
                    break;

                case 3:
                    EmpImage.sprite = E2P3Orange;
                    break;

                case 4:
                    EmpImage.sprite = E2P4Orange;
                    break;

                case 5:
                    EmpImage.sprite = E2P5Orange;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Level_3_Emp_Animation(int index)
    {
        if (EmpImage != null)
        {
            switch (SC_DefinedVariables.Slot_values[index])
            {
                case SC_GlobalEnums.Fruits.Cherry:
                    StartCoroutine(Level_3_Cherry());
                    break;

                case SC_GlobalEnums.Fruits.Banana:
                    StartCoroutine(Level_3_Banana());
                    break;

                case SC_GlobalEnums.Fruits.Kiwi:
                    StartCoroutine(Level_3_Kiwi());
                    break;

                case SC_GlobalEnums.Fruits.Raspberry:
                    StartCoroutine(Level_3_Raspberry());
                    break;

                case SC_GlobalEnums.Fruits.Coconut:
                    StartCoroutine(Level_3_Coconut());
                    break;

                case SC_GlobalEnums.Fruits.Watermelon:
                    StartCoroutine(Level_3_Watermelon());
                    break;

                case SC_GlobalEnums.Fruits.Orange:
                    StartCoroutine(Level_3_Orange());
                    break;

                default:
                    break;
            }
        }
    }

    private IEnumerator Level_3_Cherry()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E3P1Cherry;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E3P2Cherry;
                    break;

                case 3:
                    EmpImage.sprite = E3P3Cherry;
                    break;

                case 4:
                    EmpImage.sprite = E3P4Cherry;
                    break;

                case 5:
                    EmpImage.sprite = E3P5Cherry;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_3_Banana()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E3P1Banana;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E3P2Banana;
                    break;

                case 3:
                    EmpImage.sprite = E3P3Banana;
                    break;

                case 4:
                    EmpImage.sprite = E3P4Banana;
                    break;

                case 5:
                    EmpImage.sprite = E3P5Banana;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_3_Kiwi()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E3P1Kiwi;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E3P2Kiwi;
                    break;

                case 3:
                    EmpImage.sprite = E3P3Kiwi;
                    break;

                case 4:
                    EmpImage.sprite = E3P4Kiwi;
                    break;

                case 5:
                    EmpImage.sprite = E3P5Kiwi;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_3_Raspberry()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E3P1Raspberry;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E3P2Raspberry;
                    break;

                case 3:
                    EmpImage.sprite = E3P3Raspberry;
                    break;

                case 4:
                    EmpImage.sprite = E3P4Raspberry;
                    break;

                case 5:
                    EmpImage.sprite = E3P5Raspberry;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_3_Coconut()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E3P1Coconut;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E3P2Coconut;
                    break;

                case 3:
                    EmpImage.sprite = E3P3Coconut;
                    break;

                case 4:
                    EmpImage.sprite = E3P4Coconut;
                    break;

                case 5:
                    EmpImage.sprite = E3P5Coconut;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_3_Watermelon()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E3P1Watermelon;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E3P2Watermelon;
                    break;

                case 3:
                    EmpImage.sprite = E3P3Watermelon;
                    break;

                case 4:
                    EmpImage.sprite = E3P4Watermelon;
                    break;

                case 5:
                    EmpImage.sprite = E3P5Watermelon;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_3_Orange()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E3P1Orange;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E3P2Orange;
                    break;

                case 3:
                    EmpImage.sprite = E3P3Orange;
                    break;

                case 4:
                    EmpImage.sprite = E3P4Orange;
                    break;

                case 5:
                    EmpImage.sprite = E3P5Orange;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Level_4_Emp_Animation(int index)
    {
        if (EmpImage != null)
        {
            switch (SC_DefinedVariables.Slot_values[index])
            {
                case SC_GlobalEnums.Fruits.Cherry:
                    StartCoroutine(Level_4_Cherry());
                    break;

                case SC_GlobalEnums.Fruits.Banana:
                    StartCoroutine(Level_4_Banana());
                    break;

                case SC_GlobalEnums.Fruits.Kiwi:
                    StartCoroutine(Level_4_Kiwi());
                    break;

                case SC_GlobalEnums.Fruits.Raspberry:
                    StartCoroutine(Level_4_Raspberry());
                    break;

                case SC_GlobalEnums.Fruits.Coconut:
                    StartCoroutine(Level_4_Coconut());
                    break;

                case SC_GlobalEnums.Fruits.Watermelon:
                    StartCoroutine(Level_4_Watermelon());
                    break;

                case SC_GlobalEnums.Fruits.Orange:
                    StartCoroutine(Level_4_Orange());
                    break;

                default:
                    break;
            }
        }
    }

    private IEnumerator Level_4_Cherry()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E4P1Cherry;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E4P2Cherry;
                    break;

                case 3:
                    EmpImage.sprite = E4P3Cherry;
                    break;

                case 4:
                    EmpImage.sprite = E4P4Cherry;
                    break;

                case 5:
                    EmpImage.sprite = E4P5Cherry;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_4_Banana()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E4P1Banana;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E4P2Banana;
                    break;

                case 3:
                    EmpImage.sprite = E4P3Banana;
                    break;

                case 4:
                    EmpImage.sprite = E4P4Banana;
                    break;

                case 5:
                    EmpImage.sprite = E4P5Banana;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_4_Kiwi()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E4P1Kiwi;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E4P2Kiwi;
                    break;

                case 3:
                    EmpImage.sprite = E4P3Kiwi;
                    break;

                case 4:
                    EmpImage.sprite = E4P4Kiwi;
                    break;

                case 5:
                    EmpImage.sprite = E4P5Kiwi;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_4_Raspberry()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E4P1Raspberry;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E4P2Raspberry;
                    break;

                case 3:
                    EmpImage.sprite = E4P3Raspberry;
                    break;

                case 4:
                    EmpImage.sprite = E4P4Raspberry;
                    break;

                case 5:
                    EmpImage.sprite = E4P5Raspberry;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_4_Coconut()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E4P1Coconut;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E4P2Coconut;
                    break;

                case 3:
                    EmpImage.sprite = E4P3Coconut;
                    break;

                case 4:
                    EmpImage.sprite = E4P4Coconut;
                    break;

                case 5:
                    EmpImage.sprite = E4P5Coconut;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_4_Watermelon()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E4P1Watermelon;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E4P2Watermelon;
                    break;

                case 3:
                    EmpImage.sprite = E4P3Watermelon;
                    break;

                case 4:
                    EmpImage.sprite = E4P4Watermelon;
                    break;

                case 5:
                    EmpImage.sprite = E4P5Watermelon;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Level_4_Orange()
    {
        for (int i = 0; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    EmpImage.sprite = E4P1Orange;
                    EmpImage.enabled = true;
                    break;

                case 2:
                    EmpImage.sprite = E4P2Orange;
                    break;

                case 3:
                    EmpImage.sprite = E4P3Orange;
                    break;

                case 4:
                    EmpImage.sprite = E4P4Orange;
                    break;

                case 5:
                    EmpImage.sprite = E4P5Orange;
                    break;

                case 6:
                    EmpImage.enabled = false;
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}