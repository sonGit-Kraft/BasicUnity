using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{
    public GameObject bullet; // �̻��� ������ ������ ����
                              // GameObject: ��� ���� ������Ʈ�� �⺻ Ŭ����
    void Start()
    {
        // InvokeRepeating()�� Ư�� �޼��带 ������ �������� �ݺ� ȣ��
        // InvokeRepeating("�޼����̸�", ���۽ð�, �ݺ��ð�);
        InvokeRepeating("Shoot", 1f, 5f);
    }

    void Shoot()
    {
        // �̻��� ������, ��ó ������, ���Ⱚ ����
        // Instantiate()�� Unity���� ���� ������Ʈ �Ǵ� �������� ����(�ν��Ͻ�ȭ) �ϴ� �Լ�
        Instantiate(bullet, transform.position, Quaternion.identity);

        // �Ѿ� �߻� ���� (���� �Ŵ������� �Ѿ� �߻� ���� ���� �Լ� ȣ�� (�̱��� ���))
        //SoundManager.instance.PlayBulletSound();
    }
}