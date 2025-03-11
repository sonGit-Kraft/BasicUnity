using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;
    public GameObject explosion;

    void Start()
    {
           
    }

    void Update()
    {
        // Y�� �̵�
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    // �̻����� ȭ�� ������ ������
    private void OnBecameInvisible()
    {
        // �̻��� �����
        Destroy(gameObject); // gameObject: �ڱ� �ڽ�
    }

    // 2D ���� �浹 ���� Ʈ���� �̺�Ʈ
    // �ٸ� Collider2D�� Ʈ����(Collider2D + IsTrigger Ȱ��ȭ) ������ ������ �� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Ѿ˰� ���� �ε���
        // if(other.gameObject.tag == "Enemy") // �浹�� object�� �±װ� "Enemy" �� ��
        if (collision.gameObject.CompareTag("Enemy")) // CompareTag -> �� �� ���������� ��
        {                                             
            // ���� ������, �Ѿ� ������, ���Ⱚ ����
            Instantiate(explosion, transform.position, Quaternion.identity); // ���� ����Ʈ ����
            SoundManager.instance.PlayDieSound(); // ���� ����
            GameManager.instance.AddScore(10); // ���� �÷��ֱ�
            Destroy(collision.gameObject); // �� �����
            Destroy(gameObject); // �Ѿ� �����
        }
    }

    /* Unity �浹 ó��
    1. �浹�� ���� �ʿ��� ����
    - �� ������Ʈ�� 2D �ݶ��̴�(Collider2D)�� �־�� ��
    - �� �� �ϳ��� Rigidbody2D�� ������ �浹 ���� ����

    2. �浹 �̺�Ʈ ����

    // IsTrigger�� üũ���� ���� ����

    // �ٸ� Collider2D�� �浹���� �� (����)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "��(��) �浹��!");
    }

    // �浹�� ��ӵǴ� ���� (�����Ӹ��� �����)
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "��(��) �浹 ��...");
    }

    // �浹�� ������ �� (Collider���� ���)
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "��(��) �浹 ����");
    }

    // IsTrigger�� üũ�� ���� (�հ� ���� �浹)

    // Ʈ���ſ� �������� �� (����)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + "��(��) Ʈ���ſ� ����!");
    }

    // Ʈ���� ���ο� �ӹ��� �� (�����Ӹ��� �����)
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + "��(��) Ʈ���� ���ο� ����...");
    }

    // Ʈ���ſ��� ����� �� (����)
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + "��(��) Ʈ���ſ��� ����");
    }
    */
}
