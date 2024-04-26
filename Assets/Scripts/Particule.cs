using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Particule : MonoBehaviour
{
    TextMeshProUGUI _textComponent;

    public float TimeToLive = 0.15f;
    public Color ColorText;
    public string TextText;

    private void Start()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
        _textComponent.text = TextText;
        _textComponent.color = ColorText;
    }

    private void Update()
    {
        TimeToLive -= Time.deltaTime;

        if (TimeToLive <= 0)
            Destroy(this.gameObject);
    }
}
