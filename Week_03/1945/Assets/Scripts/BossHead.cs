using UnityEngine;

public class BossHead : MonoBehaviour
{
    [SerializeField] // ����ȭ
    GameObject Bossbullet; 

    // �ִϸ��̼ǿ��� �Լ� ���
    public void RightDownLaunch()
    {
        GameObject go = Instantiate(Bossbullet, transform.position, Quaternion.identity);

        go.GetComponent<BossBullet>().Move(new Vector2(1, -1)); // ������ �Ʒ� ����
    }

    public void LeftDownLaunch()
    {
        GameObject go = Instantiate(Bossbullet, transform.position, Quaternion.identity);

        go.GetComponent<BossBullet>().Move(new Vector2(-1, -1)); // ���� �Ʒ� ����
    }

    public void DownLaunch()
    {
        GameObject go = Instantiate(Bossbullet, transform.position, Quaternion.identity);

        go.GetComponent<BossBullet>().Move(new Vector2(0, -1)); // �Ʒ� ����
    }
}
