using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Buttons : MonoBehaviour
{
    [SerializeField] KeyCode _keyPressed;

    [SerializeField] float _valuePass;
    [SerializeField] float _valueCorrect;
    [SerializeField] float _valuePerfect;

    [SerializeField] float _valueDamage;

    private Transform _buttonObj;
    private int _i;

    private void Start()
    {
        _buttonObj = this.transform;
        _i = 0;
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

        if (_i <= icones.Valids.Length && icones.Valids[_i] != null)
        {
            float buttonY = _buttonObj.position.y;
            float iconeY = icones.Valids[_i].transform.position.y;
            float difference = iconeY - buttonY;
            int scoreAdd = 0;

            //Debug.Log($" button y : {buttonY}\n icone y : {iconeY}\n difference : {difference}");

            if (difference > _valuePass)
            {
                Debug.Log("Raté");
                Heal(0);

                GameManager.Instance.Ui.ComboValue = 0;
            }
            else if (difference < _valuePass && difference > -_valuePass)
            {
                if (difference < _valuePerfect && difference > -_valuePerfect)
                {
                    Debug.Log("Parfait chef");
                    Heal(0.1f);
                    scoreAdd = 100;
                }
                else if (difference < _valueCorrect && difference > -_valueCorrect)
                {
                    Debug.Log("Ca va frero");
                    Heal(0.05f);
                    scoreAdd = 50;
                }
                else if (difference < _valuePass && difference > -_valuePass)
                {
                    Debug.Log("Comment ca mon reuf ?");
                    Heal(0.01f);
                    scoreAdd = 10;
                }

                if (GameManager.Instance.LifePoints == 1)
                {
                    scoreAdd *= 2;
                }

                GameManager.Instance.Ui.ScoreValue += scoreAdd;
                GameManager.Instance.Ui.ComboValue++;
                GameManager.Instance.Ui.UpdateUi();

                Destroy(icones.Valids[_i]);
                if (_i < icones.Valids.Length)
                    _i++;
            }
            else
            {
                Heal(0);
                
                GameManager.Instance.Ui.UpdateUi();

                GameManager.Instance.Ui.ComboValue = 0;

                Destroy(icones.Valids[_i]);
                if (_i < icones.Valids.Length)
                    _i++;
            }
        }
    }

    void FeedBack()
    {
        _buttonObj.DOComplete();
        _buttonObj.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 1);
    }

    void Heal(float value)
    {
        if (GameManager.Instance.LifePoints < 1)
            GameManager.Instance.LifePoints += value + _valueDamage;
    }
}
