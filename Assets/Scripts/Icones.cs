using UnityEngine;

public class Icones : MonoBehaviour
{
    public float Speed;

    private void Start()
    {
        Speed = (float)GameManager.Instance.clip.length / Speed;
    }

    private void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }
}
