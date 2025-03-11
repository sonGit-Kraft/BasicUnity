using UnityEngine;

public class Player : MonoBehaviour
{
    // �����̴� �ӵ� ����
    public float moveSpeed = 5.0f;
    public GameObject playerHit;

    /*
    Update()
    - ������ ������ ����ȴ�.��, ������ ������ �ӵ�(FPS)�� ���� ���� Ƚ���� �޶�����.
    - �Ϲ����� ����(�Է� ó��, UI ������Ʈ, �ִϸ��̼� ��)�� ���ȴ�.
    - �����Ӹ��� ����ǹǷ� �ұ�Ģ���� ���� ������ ���� �� �ִ�.

    FixedUpdate()
    - ������ �ð� ����(�⺻��: 0.02��)**���� ����ȴ�. (���� ������ ����ȭ��)
    - Unity�� ���� ����(Physics) ���� �۾��� ó���ϴ� �� ���ȴ�.
    - Time.fixedDeltaTime �������� ����ǹǷ�, ������ �ð� ������ �����Ѵ�.

    �Ϲ����� ���� (�÷��̾� �Է�, �ִϸ��̼� ��) �� Update()
    ���� ���� (Rigidbody �̵�, �浹 ���� ��) �� FixedUpdate()
    */

    void FixedUpdate() // FixedUpdate�� �ϸ� �� �浹 �� ������ ����
    {
        moveControl();
    }

    void moveControl()
    {
        // �Էµ� ����(Axis)�� Ȯ���ϰ� �ӵ��� �ð� ���� ���� �̵��� �Ÿ� ���
        float distanceX = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * moveSpeed; // Horizontal: �¿� Ű, FixedUpdate�̱� ������ Time.fixedDeltaTime ��� 
        // �̵�����ŭ ������ �̵������ִ� �Լ�
        transform.Translate(distanceX, 0, 0); // �¿츸 �̵�
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾�� ���� �ε���
        // if(other.gameObject.tag == "Enemy") // �浹�� object�� �±װ� "Enemy" �� ��
        if (collision.gameObject.CompareTag("Enemy")) // CompareTag -> �� �� ���������� ��
        {
            GameManager.instance.DecreaseHp(10); // Hp ����
            Instantiate(playerHit, transform.position, Quaternion.identity); // ��Ʈ ����Ʈ ����

            if (GameManager.instance.hp <= 0)
            {
                Destroy(gameObject, 0.5f); // 0.5�� �� �÷��̾� ����
                Invoke("QuitGame", 0.5f); // 0.5�� �� ���� ����
            }
        }
    }
}