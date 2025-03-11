using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyBullet : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public GameObject explosion;

    void Update()
    {
        // Y�� �̵�
        transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
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
        // �浹�� object�� �±װ� "Player" �� ��
        if (collision.gameObject.CompareTag("Player")) // CompareTag -> �� �� ���������� ��
        {
            Instantiate(explosion, transform.position, Quaternion.identity); // ���� ����Ʈ ����
            GameManager.instance.DecreaseHp(10); // Hp ����
            Destroy(gameObject); // �Ѿ� �����
            if (GameManager.instance.hp <= 0)
                Invoke("QuitGame", 0.5f); // 0.5�� �� ���� ����
        }
    }
}