using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance = null;
    public static GameManager Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public VideoClip clip;
    public UI Ui;
    public SpawnIcone SpawnIcon;

    [Range(0f, 1f)]
    public float LifePoints;

    public void GameOver()
    {
        if (LifePoints > 0)
            return;

        Debug.Log("You dead");
    }
}
