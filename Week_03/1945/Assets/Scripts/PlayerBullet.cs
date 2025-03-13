using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // ���ǵ�
    public float Speed = 4.0f;
    // ���ݷ�

    // ����Ʈ
    public GameObject effect;

    void Update()
    {
        // �̻��� ���� ���� �̵�
        // �� ���� * ���ǵ� * Ÿ��
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    // ȭ�� ������ ���� ���
    private void OnBecameInvisible()
    {
        // �ڱ� �ڽ� �����
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            // ����Ʈ ����
            GameObject obj = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(obj, 1);// 1�� �ڿ� �����

            Destroy(collision.gameObject); // ���� ����
            Destroy(gameObject); // �̻��� ����
        }
    }
}