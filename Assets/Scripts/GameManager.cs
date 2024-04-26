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


    public float ValuePass;
    public float ValueCorrect;
    public float ValuePerfect;

    [SerializeField] float _valueDamage;
    [SerializeField] Transform[] _buttons;

    public VideoClip clip;
    public UI Ui;
    public SpawnIcone SpawnIcon;
    public int ActualI;

    [Range(0f, 1f)]
    public float LifePoints;

    private void Start()
    {
        ActualI = 0;
    }

    private void Update()
    {
        if (SpawnIcon.Valids[GameManager.Instance.ActualI] != null)
        {
            if (_buttons[0].position.y - SpawnIcon.Valids[GameManager.Instance.ActualI].transform.position.y > ValuePass * 1.5f)
            {
                GameManager.Instance.Ui.UpdateUi();

                GameManager.Instance.Ui.ComboValue = 0;

                Destroy(SpawnIcon.Valids[GameManager.Instance.ActualI]);
                if (GameManager.Instance.ActualI < SpawnIcon.Valids.Length)
                    GameManager.Instance.ActualI++;
            }
        }

        Heal(0);
    }

    public void GameOver()
    {
        if (LifePoints > 0)
            return;

        Debug.Log("You dead");
    }

    public void Heal(float value)
    {
        if (GameManager.Instance.LifePoints < 1)
            GameManager.Instance.LifePoints += value + _valueDamage;
    }
}
