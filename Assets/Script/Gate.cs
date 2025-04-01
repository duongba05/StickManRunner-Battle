using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    public int value = 5;
    public bool isMultiplier = false;
    public TextMeshPro gateText;

    void Start()
    {
        gateText.text = isMultiplier ? "x" + value : "+" + value;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CrowdManager crowd = other.GetComponent<CrowdManager>();
            if (crowd != null)
            {
                if (isMultiplier)
                    crowd.MultiplyStickmen(value);
                else
                    crowd.AddStickmen(value);
            }
            Destroy(gameObject);
        }
    }
}