using DG.Tweening;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public float ValuePass;
    public float ValueCorrect;
    public float ValuePerfect;
    public TextAsset TextFileLD;

    [Header("")]
    [SerializeField] float _valueDamage;
    [SerializeField] Transform[] _buttons;
    [SerializeField] GameObject _icones;

    [Header("")]
    public GameObject ParticulePrefab;
    public Transform ParticuleParent;
    public VideoClip clip;
    public VideoPlayer clipPlayer;
    public UI Ui;
    public SpawnIcone SpawnIcon;
    public int ActualI;

    [Header("")]
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

                Particules("Miss", Color.red);
            }
        }

        if (ActualI >= SpawnIcon.Valids.Length - 1)
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

    public void Particules(string text, Color color)
    {
        var P = Instantiate(ParticulePrefab, new Vector3(SpawnIcon.Valids[ActualI].transform.position.x, _buttons[0].position.y + 1.2f, 0), Quaternion.identity, ParticuleParent);
        P.GetComponent<Particule>().TextText = text;
        P.GetComponent<Particule>().ColorText = color;
        P.transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.15f);
    }
}
