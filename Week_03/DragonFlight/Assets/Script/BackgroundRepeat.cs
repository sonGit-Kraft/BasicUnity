using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    // ��ũ���� �ӵ��� ����
    // ����Ƽ �ν����Ϳ��� ���� �����ߴٸ�, ����Ƽ �ν����Ϳ��� ������ ���� ���� (�ڵ忡�� ���� �ʱ�ȭ�ϰų� �����ϴ� �κ��� ���ٸ�)
    public float scrollSpeed = 0.5f;

    //������ Material �����͸� �޾ƿ� ��ü ����
    private Material thisMaterial;

    void Start()
    {
        // ��ü�� ������ �� ���� 1ȸ ȣ��Ǵ� �Լ�
        // ���� ��ü�� Component���� ������ Renderer��� Component�� Material ���� �޾ƿ�
        thisMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // ���Ӱ� �������� Offset ��ü ����
        Vector2 newoffset = thisMaterial.mainTextureOffset; // ���� ������ ����� �ؽ�ó�� ������(�̵�)�� ��Ÿ���� Vector2 �� ����

        // ��ũ�� �ӵ��� �������� �����ؼ� ���� Y���� ������
        newoffset.Set(0, newoffset.y + (scrollSpeed * Time.deltaTime));

        // ���������� Offset ���� ����
        thisMaterial.mainTextureOffset = newoffset;
    }
}