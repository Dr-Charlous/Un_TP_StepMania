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
    [SerializeField] GameObject _icones;

    public VideoClip clip;
    public VideoPlayer clipPlayer;
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
        if (SpawnIcon.Valids[ActualI] != null)
        {
            if (_buttons[0].position.y - SpawnIcon.Valids[ActualI].transform.position.y > ValuePass * 1.5f)
            {
                Ui.ComboValue = 0;

                Destroy(SpawnIcon.Valids[ActualI]);
                if (ActualI < SpawnIcon.Valids.Length)
                    ActualI++;

                Heal(0);

                Ui.UpdateUi();
            }
        }

        if (ActualI >= SpawnIcon.Valids.Length)
        {
            GameWin();
        }
    }

    public void GameOver()
    {
        if (LifePoints > 0)
            return;

        clipPlayer.Pause();
        Ui.LoseScreen.SetActive(true);

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].gameObject.SetActive(false);
        }
        _icones.gameObject.SetActive(false);
    }

    public void GameWin()
    {
        clipPlayer.Pause();
        Ui.WinScreen.SetActive(true);
    }

    public void Heal(float value)
    {
        LifePoints += value + _valueDamage;

        if (LifePoints > 1)
            LifePoints = 1;
        else if (LifePoints <= 0)
            GameOver();

        Ui.UpdateUi();
    }
}
