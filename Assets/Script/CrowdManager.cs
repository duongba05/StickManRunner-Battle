using UnityEngine;
using System.Collections.Generic;

public class CrowdManager : MonoBehaviour
{
    public GameObject stickmanPrefab; // Prefab stickman đơn lẻ
    public int crowdSize = 1;
    private List<GameObject> stickmen = new List<GameObject>();
    public float radius = 1f; // Bán kính đám đông

    void Start()
    {
        UpdateCrowd();
    }

    public void AddStickmen(int amount)
    {
        crowdSize += amount;
        if (crowdSize < 0) crowdSize = 0;
        UpdateCrowd();
    }

    public void MultiplyStickmen(int multiplier)
    {
        crowdSize *= multiplier;
        UpdateCrowd();
    }

    void UpdateCrowd()
    {
        // Xóa stickman cũ
        foreach (var stickman in stickmen)
        {
            Destroy(stickman);
        }
        stickmen.Clear();

        // Tạo stickman mới
        for (int i = 0; i < crowdSize; i++)
        {
            float angle = i * Mathf.PI * 2 / crowdSize;
            Vector3 offset = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Vector3 position = transform.position + offset;
            GameObject newStickman = Instantiate(stickmanPrefab, position, Quaternion.identity);
            newStickman.transform.parent = transform;
            stickmen.Add(newStickman);
        }
    }
}