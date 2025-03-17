using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int Hp = 100;
    public float Speed = 3f;
    public float Delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;

    // ������ ��������
    public GameObject Item = null;

    void Start()
    {
        // Invoke: �ַ� ��������Ʈ �Ǵ� �޼��带 ȣ���� �� ���
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);

        // ��� ȣ��
        Invoke("CreateBullet", Delay);
        // ��� ����� �ȴٸ� Start()���� InvokeRepeating() ���� ��

    }
    void Update()
    {
        // �Ʒ� �������� ��������
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        //PoolManager.Instance.Return(gameObject);
    }

    // �̻��Ͽ� ���� ������ �Դ� �Լ�
    public void Damage(int attack)
    {
        Hp -= attack;

        if(Hp <= 0)
        {
            ItemDrop();
            Destroy(gameObject);
            //PoolManager.Instance.Return(gameObject);
        }
    }    

    public void ItemDrop()
    {
        // ������ ����
        Instantiate(Item, transform.position, Quaternion.identity);
    }
}