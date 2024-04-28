using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnIcone : MonoBehaviour
{
    [SerializeField] GameObject[] _iconePrefab;
    [SerializeField] Transform _iconeParent;
    [SerializeField] SongManager _song;
    [SerializeField] float _speed;

    public GameManager Manager;

    string[] _valuesText;
    float _time = 0;
    int _i = 1;
    int _j = 0;

    public GameObject[] Valids;

    void Start()
    {
        _valuesText = File.ReadAllLines(AssetDatabase.GetAssetPath(Manager.TextFileLD));
        _time = 0;

        Valids = new GameObject[_valuesText.Length];
    }

    private void Update()
    {
        if (_i < _valuesText.Length)
        {
            _time += Time.deltaTime;

            float timeValue = Mathf.Round(_time * 10f) / 10f;
            float LDValue = Mathf.Round(float.Parse(_valuesText[_i]) * 100f) / 100f;
            float timeDelay = 9.5f / ((float)Manager.clip.length / _speed);

            if (timeValue >= LDValue - timeDelay)
            {
                _i++;
                Spawn();
            }

            //Debug.Log($"{timeValue}       " +
            //    $"{LDValue - 1}       " +
            //    $"{_i}");
        }
    }

    void Spawn()
    {
        int rnd = Random.Range(0, _iconePrefab.Length);

        Valids[_j] = Instantiate(_iconePrefab[rnd], _iconeParent);
        Valids[_j].GetComponent<Icones>().Speed = _speed;
        _j++;
    }
}
