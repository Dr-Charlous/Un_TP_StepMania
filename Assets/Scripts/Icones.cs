using UnityEngine;

public class Icones : MonoBehaviour
{
    private float _speed;

    private void Start()
    {
        _speed = (float)GameManager.Instance.clip.length / 30f;
    }

    private void Update()
    {
        transform.position += Vector3.down * _speed * Time.deltaTime;
    }
}
