using System.Globalization;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    private float spawnDelay;
    private float delayCheck;

    void Start()
    {
        //Проверяем значения переменных в полях, если формат значения правильный, а само значение больше 0, тогда запускаем цикл
        if (float.TryParse(GameObject.Find("DelayInputField").GetComponent<TMPro.TMP_InputField>().text, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out float delay) && delay > 0)
        {
            delayCheck = spawnDelay = delay; // две переменные нужны для того чтобы в дальнейшем можно было изменить задержку спавна на лету
            InvokeRepeating(nameof(SpawnObject), 0, spawnDelay);
        }
    }

    public void SpawnObject() 
    {
        // парсим три поля с расстоянием, скоростью и задержкой, передаем значения в скрипт, управляющий движением куба. Расстояние и задержку так же проверяем на 0, потому что они не могут быть отрицательными,
        // скорость же может быть отрицательной, тогда объект отправится в противоположную сторону по оси Х
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
        
        // создаем куб
        Instantiate(prefab, new Vector3(0, 0.5f, 0), Quaternion.identity);

        // проверяем изменилось ли значение задержки, если да - перезапускаем цикл с новыми параметрами
        if (!Mathf.Equals(delayCheck, spawnDelay))
        {
            CancelInvoke(nameof(SpawnObject));
            InvokeRepeating(nameof(SpawnObject), 0, spawnDelay);
            delayCheck = spawnDelay;
        }
    }
}
