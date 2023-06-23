using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class result_panel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI win_text;
    [SerializeField]
    private TextMeshProUGUI lose_text;
    [SerializeField]
    private Image panel;
    [SerializeField]
    private Button replay_button;
    [SerializeField]
    private Button next_button;

    public void showResultWining()
	{
        win_text.gameObject.SetActive(true);

        panel.gameObject.SetActive(true);
        replay_button.gameObject.SetActive(true);
        next_button.gameObject.SetActive(true);
	}
    public void showResultLosing()
	{
        lose_text.gameObject.SetActive(true);

        panel.gameObject.SetActive(true);
        replay_button.gameObject.SetActive(true);
        //next_button.gameObject.SetActive(true);
	}

    public void clickedReplayButton()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    public void clickedNextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
