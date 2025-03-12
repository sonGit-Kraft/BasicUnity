using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    //public GameObject explosion;

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

    /*
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
    */
}
