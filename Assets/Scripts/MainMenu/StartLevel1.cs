using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartLevel1 : MonoBehaviour
{
    public Text SpaceText;
    bool inputEnabled;

    private void Start()
    {
        inputEnabled = false;
        SpaceText.gameObject.SetActive(false);
        StartCoroutine(WaitToEnableText());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && inputEnabled == true)
        {
            SceneManager.LoadScene("Level1");
        }

        else
        {
            return;
        }
    }

    IEnumerator WaitToEnableText()
    {
        yield return new WaitForSeconds(25);
        inputEnabled = true;
        SpaceText.gameObject.SetActive(true);
    }
}
