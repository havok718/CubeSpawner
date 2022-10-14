using UnityEngine;

public class PrefabMover : MonoBehaviour
{
    public float speed;
    public float distance;

    void FixedUpdate()
    {
        // ���������� ������ � �������� ��������� �� ��� �
        transform.Translate(new Vector3(speed,0,0));

        // ��������� ������ �� ������ �������� ����������, ���� �� - ���������� ������
        if (Mathf.Abs(transform.position.x) > distance)
        {
            Destroy(transform.gameObject);
        }
    }
}
