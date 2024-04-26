using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using DG.Tweening;

public class UI : MonoBehaviour
{
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] TextMeshProUGUI _score;
    [SerializeField] TextMeshProUGUI _combo;
    [SerializeField] SongManager _song;
    [SerializeField] Image _LifeBar;

    public GameObject WinScreen;
    public GameObject LoseScreen;

    public int ScoreValue;
    public int ComboValue;

    private void Start()
    {
        _videoPlayer.clip = GameManager.Instance.clip;

        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);

        UpdateUi();
    }

    public void UpdateUi()
    {
        _score.text = ScoreValue.ToString();
        _combo.text = ComboValue.ToString();

        _LifeBar.fillAmount = GameManager.Instance.LifePoints;

        _score.transform.DOComplete();
        _score.transform.DOPunchScale(new Vector3(0.05f, 0.1f, 0), 1.5f);
    }
}
