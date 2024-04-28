using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ChangeScene(string text)
    {
        SceneManager.LoadScene(text);
    }

    public void ChangeWindow(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }
}
