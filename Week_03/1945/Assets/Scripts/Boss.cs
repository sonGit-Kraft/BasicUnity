using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int flag = 1;
    int speed = 2;

    public GameObject mb;
    public GameObject mb2;
    public Transform pos1;
    public Transform pos2;

    void Start()
    {
        StartCoroutine(BossMissile());
        StartCoroutine(CircleFire());
    }

    IEnumerator BossMissile()
    {
        while (true)
        {
            Instantiate(mb, pos1.position, Quaternion.identity);
            Instantiate(mb, pos2.position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator CircleFire()
    {
        // ���ݷ�
        float attackRate = 3;
        // �߻�ü ���� ����
        int count = 30;
        // �߻�ü ������ ����
        float intervalAngle = 360 / count;
        // ���ߵǴ� ����
        float weightAngle = 0f;

        // �� ���·� �߻��ϴ� �߻�ü ���� (count ���� ��ŭ)
        while (true)
        {
            for (int i = 0; i < count; i++)
            {
                // �߻�ü ����
                GameObject clone = Instantiate(mb2, transform.position, Quaternion.identity);

                // �߻�ü �̵� ���� (����)
                float angle = weightAngle + intervalAngle * i;

                // �߻�ü �̵� ���� (����)
                // cos(����) ���� ������ ���� ǥ���� ���� pi/180 ����
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                // sin(����) ���� ������ ���� ǥ���� ���� pi/180 ����
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                // �߻�ü �̵� ���� ����
                clone.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }
            // �߻�ü�� �����Ǵ� ���� ���� ����
            weightAngle += 1;

            // 3�ʸ��� �̻��� �߻�
            yield return new WaitForSeconds(attackRate);
        }
    }

    private void Update()
    {
        if (transform.position.x >= 1)
            flag *= -1;
        if (transform.position.x <= -1)
            flag *= -1;

        transform.Translate(flag * speed * Time.deltaTime, 0, 0);
    }
}