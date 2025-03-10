using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // �� (Rigidbody)
    public Vector3 offset; // ī�޶�� �� ������ ������ (ȸ�� ����)

    void Start()
    {
        // ī�޶��� �ʱ� �������� ����
        offset = transform.position - target.position; // ���� ī�޶�� �� ������ �Ÿ� ���
    }

    void Update()
    {
        // ī�޶� ��ġ ��� (ȸ���� ���̸� ������ ä ���� ���󰡵���)
        Vector3 targetPosition = target.position + offset; // ���� �� ��ġ���� offset��ŭ �Ÿ� ����

        // ī�޶� ��ġ ����
        transform.position = targetPosition;

        // ī�޶� ȸ������ �ʵ��� (ȸ�� ����)
        // update���� ����Ͽ� ��� X�� �������� 25�� ȸ���� ���°� ����
        transform.rotation = Quaternion.Euler(25.0f, 0.0f, 0.0f);
    }
}