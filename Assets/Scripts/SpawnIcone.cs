using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnIcone : MonoBehaviour
{
    [SerializeField] GameObject[] _iconePrefab;
    [SerializeField] Transform _iconeParent;
    [SerializeField] SongManager _song;

    string[] _valuesText;
    float _time = 0;
    int _i = 1;
    int _j = 0;

    public GameObject[] Valids;

    void Start()
    {
        _valuesText = File.ReadAllLines(AssetDatabase.GetAssetPath(GameManager.Instance.TextFileLD));
        _time = 0;

        Valids = new GameObject[_valuesText.Length];
    }

    private void Update()
    {
        if (_i < _valuesText.Length)
        {
            _time += Time.deltaTime;

            float timeValue = Mathf.Round(_time * 10f) / 10f;
            float LDValue = Mathf.Round(float.Parse(_valuesText[_i]) * 10f) / 10f;

            if (timeValue >= LDValue - 3.3f)
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
        _j++;
    }
}
