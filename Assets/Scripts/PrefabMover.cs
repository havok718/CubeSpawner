using UnityEngine;

public class PrefabMover : MonoBehaviour
{
    public float speed;
    public float distance;

    void FixedUpdate()
    {
        // перемещаем объект с заданной скоростью по оси Х
        transform.Translate(new Vector3(speed,0,0));

        // проверяем прошел ли объект заданное расстояние, если да - уничтожаем объект
        if (Mathf.Abs(transform.position.x) > distance)
        {
            Destroy(transform.gameObject);
        }
    }
}
