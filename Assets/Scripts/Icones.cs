using UnityEngine;

public class Icones : MonoBehaviour
{
    public GameManager Manager;
    public float Speed;

    private void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }
}
