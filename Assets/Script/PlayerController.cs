using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Tốc độ tiến về phía trước
    public float sideSpeed = 3f; // Tốc độ di chuyển ngang
    public float maxSideDistance = 5f; // Giới hạn di chuyển ngang
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position; // Khởi tạo targetPosition
    }

    void Update()
    {
        // Xử lý input chuột để di chuyển ngang
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Lấy tọa độ x từ chuột, giới hạn trong khoảng maxSideDistance
                float newX = Mathf.Clamp(hit.point.x, -maxSideDistance, maxSideDistance);
                targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
            }
        }

        // Di chuyển ngang mượt mà (smoothing)
        Vector3 currentPosition = transform.position;
        float smoothX = Mathf.Lerp(currentPosition.x, targetPosition.x, sideSpeed * Time.deltaTime);

        // Tiến về phía trước
        float forwardZ = currentPosition.z + speed * Time.deltaTime;

        // Cập nhật vị trí mới
        transform.position = new Vector3(smoothX, currentPosition.y, forwardZ);
    }
}