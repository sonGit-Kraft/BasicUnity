using UnityEngine;

public class MoveWithGravity : MonoBehaviour
{
    public Rigidbody rb;

    public float jumpForce = 5.0f; // ���� ��

    void Start()
    {

    }

    void Update()
    {
        // Space Ű�� ������ ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Rigidbody: ����ȿ���� �߰��� �߷��� ����
            // AddForce: ������ ���� ������Ʈ�� ���� ��
            // ForceMode.Impulse: ���������� ���� ���ϴ� �ɼ�
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
