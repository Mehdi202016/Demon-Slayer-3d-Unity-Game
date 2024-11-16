using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Main;
    [SerializeField] GameObject PanelShop;
    [SerializeField] GameObject PanelMessage;
    [SerializeField] GameObject PanelPause;

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI ScoreKiller;

    private float index;
    //private AudioSource BackgroundSound;
    //private bool MusicOn=false;
    //public Sprite[] MusicSoundPictures;
    //public Image ImageSound;

    public int Scr = 0;
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #region Coins Score

    public static int CoinsScore = 0;

    public static int getScore()
    {
        return PlayerPrefs.GetInt("CoinsScore");
    }

    public static void AddScore(int amount)
    {
        CoinsScore = (amount + getScore());
        Debug.Log("Score : " + CoinsScore);
        PlayerPrefs.SetInt("CoinsScore", CoinsScore);
    }

    #endregion
    #region Killer Score

    public static int KillerScore = 0;

    public static int getKillers()
    {
        return PlayerPrefs.GetInt("Killer");
    }

    public static void AddKiller(int amount)
    {
        KillerScore = (amount + getKillers());
        Debug.Log("Killers : " + KillerScore);
        PlayerPrefs.SetInt("Killer", KillerScore);
    }
    #endregion

    private void Start()
    {
        Time.timeScale = 0;
        //BackgroundSound = GetComponent<AudioSource>();
        ScoreKiller.text = "Killer : "+ getKillers();
    }

    private void Update()
    {
        Score.text = getScore().ToString()+"$";
        ScoreText.text = Scr.ToString();
    }

    public void ButtonSound()
    {
        //if (MusicOn == true)
        //{
        //    BackgroundSound.Play();
        //    MusicOn = false;
        //    ImageSound.sprite = MusicSoundPictures[0];
        //}
        //else
        //{
        //    BackgroundSound.Stop();
        //    MusicOn = true;
        //    ImageSound.sprite = MusicSoundPictures[1];
        //}
    }

    public void ButtonPlayGame()
    {
        Main.SetActive(false);
        Time.timeScale = 1;
    }

    public void ButtonShowShopPanel()
    {
        PanelShop.SetActive(true);
    }
    public void ButtonHideShopPanel()
    {
        PanelShop.SetActive(false);
    }

    public void ButtonShowMessagePanel()
    {
        PanelMessage.SetActive(true);
    }
    public void ButtonHideMessagePanel()
    {
        PanelMessage.SetActive(false);
    }

    public void ButtonFedBack()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.LayStudio.Demon");
    }

    public void PanelPauseShow()
    {
        Time.timeScale = 0;
        PanelPause.SetActive(true);
    }
    public void PanelPauseHide()
    {
        Time.timeScale = 1;
        PanelPause.SetActive(false);
    }

    public void PressButton()
    {
        index++;
        Debug.Log("index : " + index);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
