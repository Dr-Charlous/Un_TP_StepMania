using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    [SerializeField] Image _songBar;
    [SerializeField] Transform _songIcone;
    public Transform Begin;
    public Transform End;

    private void Start()
    {
        _songIcone.position = Begin.position;
        _songBar.fillAmount = 0;
    }

    private void Update()
    {
        if (_songBar.fillAmount != 1)
            _songIcone.transform.position += Vector3.right * ((End.position.x - Begin.position.x) / (float)GameManager.Instance.clip.length) * Time.deltaTime;
        _songBar.fillAmount += (1 / (float)GameManager.Instance.clip.length) * Time.deltaTime;
    }
}
