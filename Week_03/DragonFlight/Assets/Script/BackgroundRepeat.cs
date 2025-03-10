using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    // ��ũ���� �ӵ��� ����� ����
    public float scrollSpeed = 1.2f;

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
        Vector2 newoffset = thisMaterial.mainTextureOffset;

        // ���� Y���� �ӵ��� ������ �����ؼ� ������
        newoffset.Set(0, newoffset.y + (scrollSpeed * Time.deltaTime));

        // ���������� Offset ���� ����
        thisMaterial.mainTextureOffset = newoffset;
    }
}