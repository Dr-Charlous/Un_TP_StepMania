using DG.Tweening;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] KeyCode _keyPressed;

    public GameManager Manager;

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
        var icones = Manager.SpawnIcon;
        var valuePerfect = Manager.ValuePerfect;
        var valueCorrect = Manager.ValueCorrect;
        var valuePass = Manager.ValuePass;

        if (Manager.ActualI <= icones.Valids.Length && icones.Valids[Manager.ActualI] != null)
        {
            float buttonY = _buttonObj.position.y;
            float iconeY = icones.Valids[Manager.ActualI].transform.position.y;
            float difference = iconeY - buttonY;
            int scoreAdd = 0;

            //Debug.Log($" button y : {buttonY}\n icone y : {iconeY}\n difference : {difference}");

            if (difference > valuePass)
            {
                Manager.Heal(0);

                Manager.Ui.ComboValue = 0;

                Manager.Particules("Miss", Color.red);
            }
            else if (difference < valuePass && difference > -valuePass && icones.Valids[Manager.ActualI].transform.position.x == transform.position.x)
            {
                if (difference < valuePerfect && difference > -valuePerfect)
                {
                    Manager.Particules("Perfect", Color.yellow);
                    Manager.Heal(0.3f);
                    scoreAdd = 100;
                }
                else if (difference < valueCorrect && difference > -valueCorrect)
                {
                    Manager.Particules("Cool", Color.green);
                    Manager.Heal(0.2f);
                    scoreAdd = 50;
                }
                else if (difference < valuePass && difference > -valuePass)
                {
                    Manager.Particules("Correct", Color.blue);
                    Manager.Heal(0.1f);
                    scoreAdd = 10;
                }

                if (Manager.LifePoints == 1)
                {
                    scoreAdd *= 2;
                }

                Manager.Ui.ScoreValue += scoreAdd;
                Manager.Ui.ComboValue++;

                Destroy(icones.Valids[Manager.ActualI]);
                if (Manager.ActualI < icones.Valids.Length)
                    Manager.ActualI++;

                Manager.Ui.UpdateUi();
            }
        }
    }

    void FeedBack()
    {
        _buttonObj.DOComplete();
        _buttonObj.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 1);
    }
}
