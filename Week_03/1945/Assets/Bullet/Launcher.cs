using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bullet; // �Ѿ� ������ ������ ����

    void Start()
    {
        // InvokeRepeating()�� Ư�� �޼��带 ������ �������� �ݺ� ȣ��
        // InvokeRepeating("�޼����̸�", ���۽ð�, �ݺ��ð�);
        InvokeRepeating("Shoot", 0.5f, 0.1f);
    }

    void Shoot()
    {
        // �Ѿ� ������, ��ó ������, ���Ⱚ ����
        // Instantiate()�� Unity���� ���� ������Ʈ �Ǵ� �������� ����(�ν��Ͻ�ȭ) �ϴ� �Լ�
        Instantiate(bullet, transform.position, Quaternion.identity);


        // �Ѿ� �߻� ���� (���� �Ŵ������� �Ѿ� �߻� ���� ���� �Լ� ȣ�� (�̱��� ���))
        // SoundManager.instance.PlayBulletSound();
    }
}
