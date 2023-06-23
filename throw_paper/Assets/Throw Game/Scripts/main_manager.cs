using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_manager : MonoBehaviour
{
    [SerializeField] private string new_level = "Level01";

    public void PlayButtonClicked()
	{
		SceneManager.LoadScene(new_level);
	}
}
