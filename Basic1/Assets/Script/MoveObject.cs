using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5.0f; // �̵� �ӵ�

    void Update()
    {
        /*
        // Vector3.right; // -> (1, 0, 0) 
        // Vector3.left;  // <- (-1, 0, 0) 
        
        // Ű �Է¿� ���� �̵� (�¿�)
        float move = Input.GetAxis("Horizontal"); // Horizontal: �¿� Ű, ����: -1 ~ 1

        // move�� ���� ���� ������ 
        // Time.deltaTime: �� �������� �ð� ������ ��Ÿ���� �� -> ������ ���� ������� ������ �ӵ��� �������� ���� (���� ���� �ε巴�� �����̰� ����)
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);
        */

        // Ű �Է¿� ���� �̵� (�����¿�)
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // Vertical: ���� Ű

        // transform.position += move * speed * Time.deltaTime;
        transform.Translate(move * speed * Time.deltaTime);
    }
}