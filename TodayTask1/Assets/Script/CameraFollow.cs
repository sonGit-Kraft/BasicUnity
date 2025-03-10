using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // �� (Rigidbody)
    public float distance = 10f; // ī�޶�� �� ������ �Ÿ�
    public float height = 5f; // ī�޶��� ����
    public Vector3 offset; // ī�޶�� �� ������ ������ (ȸ�� ����)

    void Start()
    {
        // ī�޶��� �ʱ� �������� ����
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // ī�޶� ��ġ ��� (ȸ���� ���̸� ������ ä ���� ���󰡵���)
        Vector3 targetPosition = target.position + offset;

        // ī�޶� ��ġ ����
        transform.position = targetPosition;

        // ī�޶� ȸ������ �ʵ��� (ȸ�� ����)
        transform.rotation = Quaternion.Euler(30f, 0f, 0f); // ����: ī�޶�� X�� 30��, Y�� 0�� ����
    }
}