using UnityEngine;

public class VectorExample : MonoBehaviour
{
    // public Vector2 v2 = new Vector2(10, 10); // (x, y)
    // public Vector3 v3 = new Vector3(1, 1, 1); // (x, y, z)
    
    void Start()
    {
        // ������ ���ϱ�
        Vector3 a = new Vector3(1, 1, 0);
        Vector3 b = new Vector3(2, 0, 0);

        Vector3 c = a + b; // (3, 1, 0)

        Debug.Log("Vector " + c);
        Debug.Log("����: " + c.magnitude); // ������ ���� (3, 1, 0) -> sqrt(3^2 + 1^2) = ����
                                           // ���� ��� ���� �ڷ�: https://wergia.tistory.com/209
        // ����ȭ normalize
        // ������ ũ�⸦ 1�� ����� ���⸸ ����
        Vector3 d = new Vector3(3, 0, 0);
        Vector3 normalizedVector = d.normalized;

        Debug.Log("1�� ���� ���⸸ �����ϴ� ����ȭ: " + normalizedVector);

        // ������ ����
        Vector3 e = a - b; // (3, 1, 0)
    }
    

    void Update()
    {
        
    }
}
