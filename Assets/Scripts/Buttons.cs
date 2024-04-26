using DG.Tweening;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] KeyCode _keyPressed;

    private Transform _buttonObj;

    private void Start()
    {
        _buttonObj = this.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_keyPressed))
        {
            FeedBack();
            Check();
        }
    }

    void Check()
    {
        var icones = GameManager.Instance.SpawnIcon;
        var valuePerfect = GameManager.Instance.ValuePerfect;
        var valueCorrect = GameManager.Instance.ValueCorrect;
        var valuePass = GameManager.Instance.ValuePass;

        if (GameManager.Instance.ActualI <= icones.Valids.Length && icones.Valids[GameManager.Instance.ActualI] != null)
        {
            float buttonY = _buttonObj.position.y;
            float iconeY = icones.Valids[GameManager.Instance.ActualI].transform.position.y;
            float difference = iconeY - buttonY;
            int scoreAdd = 0;

            //Debug.Log($" button y : {buttonY}\n icone y : {iconeY}\n difference : {difference}");

            if (difference > valuePass)
            {
                Debug.Log("Raté");
                GameManager.Instance.Heal(0);

                GameManager.Instance.Ui.ComboValue = 0;

                GameManager.Instance.Particules("Miss", Color.red);
            }
            else if (difference < valuePass && difference > -valuePass && icones.Valids[GameManager.Instance.ActualI].transform.position.x == transform.position.x)
            {
                if (difference < valuePerfect && difference > -valuePerfect)
                {
                    GameManager.Instance.Particules("Perfect", Color.yellow);
                    GameManager.Instance.Heal(0.3f);
                    scoreAdd = 100;
                }
                else if (difference < valueCorrect && difference > -valueCorrect)
                {
                    GameManager.Instance.Particules("Cool", Color.green);
                    GameManager.Instance.Heal(0.2f);
                    scoreAdd = 50;
                }
                else if (difference < valuePass && difference > -valuePass)
                {
                    GameManager.Instance.Particules("Correct", Color.blue);
                    GameManager.Instance.Heal(0.1f);
                    scoreAdd = 10;
                }

                if (GameManager.Instance.LifePoints == 1)
                {
                    scoreAdd *= 2;
                }

                GameManager.Instance.Ui.ScoreValue += scoreAdd;
                GameManager.Instance.Ui.ComboValue++;

                Destroy(icones.Valids[GameManager.Instance.ActualI]);
                if (GameManager.Instance.ActualI < icones.Valids.Length)
                    GameManager.Instance.ActualI++;

                GameManager.Instance.Ui.UpdateUi();
            }
        }
    }

    void FeedBack()
    {
        _buttonObj.DOComplete();
        _buttonObj.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 1);
    }
}
