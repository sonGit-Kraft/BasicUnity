using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyBullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;
    public GameObject explosion;

    void Start()
    {

    }

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
        // �Ѿ˰� ���� �ε���
        // if(other.gameObject.tag == "Enemy") // �浹�� object�� �±װ� "Enemy" �� ��
        if (collision.gameObject.CompareTag("Player")) // CompareTag -> �� �� ���������� ��
        {
            Destroy(gameObject); // �Ѿ� �����
            // ���� ������, �Ѿ� ������, ���Ⱚ ����
            Instantiate(explosion, transform.position, Quaternion.identity); // ���� ����Ʈ ����
            //SoundManager.instance.PlayDieSound(); // ���� ����
            GameManager.instance.Hp(5); // Hp ����
            Debug.Log(GameManager.instance.hp);
            
            if (GameManager.instance.hp == 0)
            {
                // ���� ������, �÷��̾� ������, ���Ⱚ ����
                //Instantiate(dieexplosion, transform.position, Quaternion.identity); // ���� ����Ʈ ����
                Invoke("QuitGame", 0.5f); // 0.5�� �� ���� ����
            }
        }
    }
}