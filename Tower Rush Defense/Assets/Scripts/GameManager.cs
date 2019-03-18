using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] Button quitGameBtn;
	void Start () {
        quitGameBtn.onClick.AddListener(QuitGame);
	}
	
	private void QuitGame()
    {
        Application.Quit();
    }
}
