using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 1.0f; // ���� �������� �ӵ�
    public float jumpForce = 5.0f; // ������ ��

    private Rigidbody rb; // Rigidbody ������Ʈ

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ���� ������ ó�� (WASD �Ǵ� ȭ��ǥ Ű�� ������)
        float horizontal = Input.GetAxis("Horizontal"); // �¿� ������
        float vertical = Input.GetAxis("Vertical"); // ���� ������

        // ���� ���ο��� ������ ���� Rigidbody�� ���� �߰�
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        rb.AddForce(moveDirection * moveSpeed, ForceMode.Force);

        // �����̽��ٷ� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // ����
        }
    }
}
