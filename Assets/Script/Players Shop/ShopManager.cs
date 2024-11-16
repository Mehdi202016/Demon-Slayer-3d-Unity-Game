using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    [Header("Shop")]
    int current_player = 0;
    public GameObject[] select_player;
    public int[] cost_player;
    string[] value_player = new string[5];
    int coins;
    public int[] buy_player;

    private void Start()
    {
        
        for (int i = 0; i < select_player.Length; i++)
        {
            value_player[i] = "" + i;
            select_player[i].SetActive(false);
            buy_player[i] = PlayerPrefs.GetInt(value_player[i]);
        }
    }
    private void Update()
    {
        coins = UIManager.getScore();
        //Debug.Log("Coins : " + coins);
        for (int i = 0; i < select_player.Length; i++)
        {
            buy_player[i] = PlayerPrefs.GetInt(value_player[i]);
            if (i == buy_player[i])
            {
                select_player[i].SetActive(true);
            }
        }
    }

    public void BuyCharacter(int io)
    {
        if (cost_player[io] <= coins)
        {
            UIManager.AddScore(-cost_player[io]);
            PlayerPrefs.SetInt(value_player[io], io);
            AdsManager.instance.ShowInterstitial();
        }
        else if (cost_player[io] > coins)
        {
            Debug.Log("Error");
        }
    }

    public void SelectCharacter(int io)
    {
        PlayerPrefs.SetInt("current_player", io);
        AdsManager.instance.ShowInterstitial();
    }
}
