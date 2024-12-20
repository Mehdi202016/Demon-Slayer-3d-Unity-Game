using UnityEngine;
using UnityEngine.UI;

public class GetIconSelected : MonoBehaviour
{
    int current_player;
    private Image SelectedCharacterIcon;
    [SerializeField] Sprite[] Icon;

    private void Start()
    {
        SelectedCharacterIcon = GetComponent<Image>();
    }

    void Update()
    {
        current_player = PlayerPrefs.GetInt("current_player", current_player);
        if (current_player == 0)
        {
            //Player 1 show
            SelectedCharacterIcon.sprite = Icon[0];
        }
        else if (current_player == 1)
        {
            //Player 2 show
            SelectedCharacterIcon.sprite = Icon[1];
        }
        else if (current_player == 2)
        {
            //Player 3 show
            SelectedCharacterIcon.sprite = Icon[2];
        }
        else if (current_player == 3)
        {
            //Player 4 show
            SelectedCharacterIcon.sprite = Icon[3];
        }
    }
}
