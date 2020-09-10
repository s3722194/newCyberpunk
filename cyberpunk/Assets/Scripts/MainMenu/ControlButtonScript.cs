using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(playGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void playGame()
    {
        Debug.Log("You have clicked the button");
        SceneManager.LoadScene("ControlsScene");
    }
}
