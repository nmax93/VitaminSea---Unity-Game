using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Buttons : MonoBehaviour {

    static bool Vol = true;
    public AudioSource Boom;
    public AudioSource Click;
    public Image SoundStatusPauseScreen;
    public Image SoundStatusMenuScreen;
    public Sprite SoundOn;
    public Sprite SoundOff;
    static SC_Buttons instance;
    public static SC_Buttons Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("SC_Buttons").GetComponent<SC_Buttons>();
            return instance;
        }
    }

    public void Singleplayer()
    {
        SC_DefinedVariables.multiplayer = false;
        SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(9).gameObject.SetActive(false);
        StartCoroutine(Loading_Singleplayer(SC_DefinedVariables.Screens["Loading_screen"]));
        SC_Logic.Instance.InitBoard();
    }

    public void Pause_Game()
    {
        SC_DefinedVariables.Screens["Pause_screen"].transform.GetChild(0).gameObject.SetActive(true);
        SC_DefinedVariables.Screens["Pause_screen"].transform.GetChild(13).gameObject.SetActive(false);
        StartCoroutine(Pause_Screen_Animation(SC_DefinedVariables.Screens["Pause_screen"]));
    }

    public void Resume()
    {
        StartCoroutine(Resume_Animation(SC_DefinedVariables.Screens["Pause_screen"]));
    }

    public void Restart_Confirmation()
    {
        StartCoroutine(Restart_Confirmation_Animation(SC_DefinedVariables.Screens["Pause_screen"]));
    }

    public void Back()
    {
        StartCoroutine(Back_Animation(SC_DefinedVariables.Screens["Pause_screen"]));
    }

    public void Restart()
    {
        SC_DefinedVariables.Score = 0;
        SC_DefinedVariables.Target = 4000;
        SC_DefinedVariables.Level = 1;
        StartCoroutine(Restart_Animation());
    }

    public void Main_Menu()
    {
        SC_DefinedVariables.Screens["Menu_screen"].SetActive(true);
        StartCoroutine(Resume_Animation(SC_DefinedVariables.Screens["Pause_screen"]));
    }

    public void Volume()
    {
        if (Vol == true)
        {
            SC_DefinedVariables.Screens["Pause_screen"].transform.GetChild(7).gameObject.GetComponent<Image>().sprite = SoundOff;
            SC_DefinedVariables.Screens["Pause_screen"].transform.GetChild(8).gameObject.GetComponent<Image>().sprite = SoundOff;
        }
        else
        {
            SC_DefinedVariables.Screens["Pause_screen"].transform.GetChild(7).gameObject.GetComponent<Image>().sprite = SoundOn;
            SC_DefinedVariables.Screens["Pause_screen"].transform.GetChild(8).gameObject.GetComponent<Image>().sprite = SoundOn;
        }
        Vol = !Vol;
    }

    public IEnumerator Loading_Singleplayer(GameObject LoadingScreen)
    {
        yield return new WaitForSeconds(0.1f);

        Color LoadingTxt = LoadingScreen.transform.GetChild(3).GetComponent<Image>().color;
        Color WhiteBackground = LoadingScreen.transform.GetChild(0).GetComponent<Image>().color;

        LoadingScreen.SetActive(true);
        LoadingTxt.a = 0f;
        WhiteBackground.a = 0f;
        LoadingScreen.transform.GetChild(0).GetComponent<Image>().color = WhiteBackground;
        LoadingScreen.transform.GetChild(4).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(5).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(6).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(7).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(8).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(9).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(10).gameObject.SetActive(false);

        for (int i = 0; i < 33; i++)
        {
            LoadingScreen.transform.GetChild(1).position = new Vector2(LoadingScreen.transform.GetChild(1).position.x - 35, LoadingScreen.transform.GetChild(1).position.y);
            LoadingScreen.transform.GetChild(2).position = new Vector2(LoadingScreen.transform.GetChild(2).position.x + 35, LoadingScreen.transform.GetChild(2).position.y);
            LoadingTxt.a += 0.03f;
            WhiteBackground.a += 0.03f;
            LoadingScreen.transform.GetChild(3).GetComponent<Image>().color = LoadingTxt;
            LoadingScreen.transform.GetChild(0).GetComponent<Image>().color = WhiteBackground;
            yield return null;
        }

        for(int i = 3; i < 7; i++)
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

    public IEnumerator Loading_Multiplyerplayer(GameObject LoadingScreen)
    {
        yield return new WaitForSeconds(0.1f);
        LoadingScreen.SetActive(true);

        Color WhiteBackground = LoadingScreen.transform.GetChild(0).GetComponent<Image>().color;

        WhiteBackground.a = 0f;
        LoadingScreen.transform.GetChild(0).GetComponent<Image>().color = WhiteBackground;
        LoadingScreen.transform.GetChild(3).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(4).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(5).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(6).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(8).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(9).gameObject.SetActive(false);
        LoadingScreen.transform.GetChild(10).gameObject.SetActive(false);

        for (int i = 0; i < 33; i++)
        {
            LoadingScreen.transform.GetChild(1).position = new Vector2(LoadingScreen.transform.GetChild(1).position.x - 35, LoadingScreen.transform.GetChild(1).position.y);
            LoadingScreen.transform.GetChild(2).position = new Vector2(LoadingScreen.transform.GetChild(2).position.x + 35, LoadingScreen.transform.GetChild(2).position.y);
            WhiteBackground.a += 0.03f;
            LoadingScreen.transform.GetChild(0).GetComponent<Image>().color = WhiteBackground;
            yield return null;
        }
    }

    private IEnumerator Pause_Screen_Animation(GameObject PauseScreen)
    {
        Color DarkBackground = PauseScreen.transform.GetChild(0).GetComponent<Image>().color;

        DarkBackground.a = 0f;
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 16; i++)
        {
            PauseScreen.transform.position = new Vector2(PauseScreen.transform.position.x, PauseScreen.transform.position.y + 158);
            PauseScreen.transform.GetChild(0).transform.position = new Vector2(PauseScreen.transform.position.x, 1280);
            DarkBackground.a += 0.02f;
            PauseScreen.transform.GetChild(0).GetComponent<Image>().color = DarkBackground;
            yield return null;
        }
    }

    private IEnumerator Restart_Confirmation_Animation(GameObject Pause_Screen)
    {
        yield return new WaitForSeconds(0.1f);
        Pause_Screen.transform.GetChild(13).gameObject.SetActive(true);
        Pause_Screen.transform.GetChild(1).gameObject.SetActive(false);
    }

    private IEnumerator Back_Animation(GameObject Pause_Screen)
    {
        yield return new WaitForSeconds(0.1f);
        Pause_Screen.transform.GetChild(13).gameObject.SetActive(false);
        Pause_Screen.transform.GetChild(1).gameObject.SetActive(true);
    }

    private IEnumerator Resume_Animation(GameObject PauseScreen)
    {
        Color DarkBackground = PauseScreen.transform.GetChild(0).GetComponent<Image>().color;

        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 16; i++)
        {
            PauseScreen.transform.position = new Vector2(PauseScreen.transform.position.x, PauseScreen.transform.position.y - 158);
            PauseScreen.transform.GetChild(0).transform.position = new Vector2(PauseScreen.transform.position.x, 1280);
            DarkBackground.a -= 0.02f;
            PauseScreen.transform.GetChild(0).GetComponent<Image>().color = DarkBackground;
            yield return null;
        }
        PauseScreen.transform.GetChild(0).gameObject.SetActive(false);
    }

    private IEnumerator Restart_Animation()
    {
        StartCoroutine(Resume_Animation(SC_DefinedVariables.Screens["Pause_screen"]));
        yield return new WaitForSeconds(1f);
        StartCoroutine(Loading_Singleplayer(SC_DefinedVariables.Screens["Loading_screen"]));
        yield return new WaitForSeconds(2f);
        SC_Logic.Instance.InitBoard();
    }

    public void multiplayer()
    {
        SC_DefinedVariables.Screens["Gameplay_screen"].transform.GetChild(9).gameObject.SetActive(true);
        SC_DefinedVariables.Screens["Login_screen"].SetActive(true);
    }

    public void multiplayer_play()
    {
        SC_DefinedVariables.userName = SC_DefinedVariables.Screens["Login_screen"].transform.GetChild(1).GetChild(1).gameObject.GetComponent<Text>().text;
        SC_DefinedVariables.password = SC_DefinedVariables.Screens["Login_screen"].transform.GetChild(2).GetChild(1).gameObject.GetComponent<Text>().text;
        StartCoroutine(Loading_Multiplyerplayer(SC_DefinedVariables.Screens["Loading_screen"]));
        SC_Multiplayer.Instance.MultiplayerInit();
    }

    public void Disable_Multiplayer()
    {
        SC_DefinedVariables.Screens["Login_screen"].SetActive(false);
    }
}