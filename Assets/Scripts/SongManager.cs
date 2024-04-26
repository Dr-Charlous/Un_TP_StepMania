using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;
using UnityEngine.UIElements;

public class SongManager : MonoBehaviour
{
    [SerializeField] Transform _songIcone;
    public Transform Begin;
    public Transform End;

    private void Start()
    {
        _songIcone.position = Begin.position;
    }

    private void Update()
    {
        _songIcone.transform.position += Vector3.right * ((End.position.x - Begin.position.x) / (float)GameManager.Instance.clip.length) * Time.deltaTime;
    }
}
