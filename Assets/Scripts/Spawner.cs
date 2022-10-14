using System.Globalization;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    private float spawnDelay;
    private float delayCheck;

    void Start()
    {
        //��������� �������� ���������� � �����, ���� ������ �������� ����������, � ���� �������� ������ 0, ����� ��������� ����
        if (float.TryParse(GameObject.Find("DelayInputField").GetComponent<TMPro.TMP_InputField>().text, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out float delay) && delay > 0)
        {
            delayCheck = spawnDelay = delay; // ��� ���������� ����� ��� ���� ����� � ���������� ����� ���� �������� �������� ������ �� ����
            InvokeRepeating(nameof(SpawnObject), 0, spawnDelay);
        }
    }

    public void SpawnObject() 
    {
        // ������ ��� ���� � �����������, ��������� � ���������, �������� �������� � ������, ����������� ��������� ����. ���������� � �������� ��� �� ��������� �� 0, ������ ��� ��� �� ����� ���� ��������������,
        // �������� �� ����� ���� �������������, ����� ������ ���������� � ��������������� ������� �� ��� �
        if (float.TryParse(GameObject.Find("DistanceInputField").GetComponent<TMPro.TMP_InputField>().text, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out float distance) && distance > 0)
        {
            prefab.GetComponent<PrefabMover>().distance = distance;
        }

        if (float.TryParse(GameObject.Find("SpeedInputField").GetComponent<TMPro.TMP_InputField>().text, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out float speed))
        {
            prefab.GetComponent<PrefabMover>().speed = speed;
        }
        
        if (float.TryParse(GameObject.Find("DelayInputField").GetComponent<TMPro.TMP_InputField>().text, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out float delay) && delay > 0)
        {
            spawnDelay = delay;
        }
        
        // ������� ���
        Instantiate(prefab, new Vector3(0, 0.5f, 0), Quaternion.identity);

        // ��������� ���������� �� �������� ��������, ���� �� - ������������� ���� � ������ �����������
        if (!Mathf.Equals(delayCheck, spawnDelay))
        {
            CancelInvoke(nameof(SpawnObject));
            InvokeRepeating(nameof(SpawnObject), 0, spawnDelay);
            delayCheck = spawnDelay;
        }
    }
}
