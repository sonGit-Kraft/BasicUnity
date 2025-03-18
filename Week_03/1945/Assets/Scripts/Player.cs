using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // ���ǵ�
    public float moveSpeed = 5.0f;

    // ȭ�� ��踦 ������ ����
    private Vector2 minBounds;
    private Vector2 maxBounds;

    // �ִϸ����͸� ������ ����
    Animator ani;

    // �̻���
    public GameObject[] bullet; // �迭�� ����
    public Transform pos = null;
    public int power = 0; // �ҷ��� �ε���

    [SerializeField]
    private GameObject powerup; // private������ inspector���� ��� ����

    // ������
    public GameObject lazer; // �迭�� ����
    public float gValue = 0;

    // ������ ��
    public Image Gage;

    void Start()
    {
        ani = GetComponent<Animator>(); // �ִϸ����� ������Ʈ ������

        Camera cam = Camera.main;
        // Camera.main.ViewportToWorldPoint(): ī�޶� ����Ʈ ��ǥ(0~1 ����)�� ���� ��ǥ�� ��ȯ�ϴ� �Լ�
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)); // (0, 0, 0) �� ȭ���� ���� �Ʒ� (bottom - left)
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0)); // (1, 1, 0) �� ȭ���� ������ �� (top - right)

        // ȭ�� ��� ����
        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        maxBounds = new Vector2(topRight.x, topRight.y);
    }

    void Update()
    {
        // ����Ű�� ���� ������
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"); // �¿� Ű
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"); // ���� Ű

        // -1 ~ 0 ~ 1
        if (Input.GetAxis("Horizontal") <= -0.25f) // ���� ���� �Է� ���� -0.25 ������ ��
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);

        if (Input.GetAxis("Horizontal") >= 0.25f) // ���� ���� �Է� ���� 0.25 �̻��� ��
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);

        if (Input.GetAxis("Vertical") >= 0.1f) // ���� ���� �Է� ���� 0.1 �̻��� ��
            ani.SetBool("up", true);
        else
            ani.SetBool("up", false);

        // �����̽��� -> �̻��� �߻�
        if (Input.GetKeyDown(KeyCode.Space)) // Ű�� �� �� ������ ���� ����
        {
            // ������, ��ġ, ����
            Instantiate(bullet[power], pos.position, Quaternion.identity);
        }
        else if (Input.GetKey(KeyCode.Space)) // Ű�� �� ������ ���� ����
        {
            gValue += Time.deltaTime;
            Gage.fillAmount = gValue;
            if (gValue >= 1)
            {
                GameObject go = Instantiate(lazer, pos.position, Quaternion.identity);
                Destroy(go, 3);
                gValue = 0;
            }
            Gage.fillAmount = gValue;
        }
        else
        {
            gValue -= Time.deltaTime;
            
            if (gValue <= 0)
            {
                gValue = 0;
            }

            Gage.fillAmount = gValue;
        }

        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        // ��踦 ����� �ʵ��� ��ġ ����
        // Mathf.Clamp(value, min, max): value�� min���� ������ min, max���� ũ�� max�� ����
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            power += 1;

            if (power >= 3)
                power = 3;
            else
            {
                // �Ŀ� ��
                GameObject go = Instantiate(powerup, transform.position, Quaternion.identity);
                Destroy(go, 1);
            }

            // ������ ���� ó��
            Destroy(collision.gameObject);
        }
    }
}