using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Panel_Object_Controller : MonoBehaviour
{
    // 1. ��ư�� ������ ��ư�� �ش��ϴ� ������Ʈ�� �����Ѵ�.
    //    1) �� ��ư�� OnClickEvent�� ������Ʈ�� �����ϴ� �Լ��� ȣ���Ѵ�.
    //    2) �� ��ư�� �Լ��� ������.
    #region ���ĽŰ�
    // <<�ʿ��� �Ӽ�: ��ġ ( position ) , ( rotation ), ( scale ) ==> ���߿� �Ű澴��. �׳� �ϴ� ����� ����.>>
    // 2. �ش� ������Ʈ�� ��ġ, rotation, scale �Ӽ��� ������.
    //    1) �� ������Ʈ�� �Ӽ��� �ҷ����� ����� ������Ʈ�� �����ϴ� �Լ� �ȿ� ����.
    //    2) �Ӽ��� 3�����̴�.
    //    3) �Ӽ��� ���� string ���·� �޾ƿ´�.
    // 3. ������Ʈ�� �Ӽ��� ���� ������ DB�� ���� �޴´�. => �ش���� �Ű� X
    // 4. DB�� ���� ��Ʈ��ũ�� ���Ͽ� �޾ƿ´�. => DB�� �����ϴ� ����/�߽ſ� �ش��ϴ� ������ ���� �����Ѵ�.
    #endregion

    // �� ������Ʈ Ÿ�� �� ��ư
    
    public Button Btn_Tetrahedron;
    public Button Btn_Hexahedron;
    public Button Btn_Sphere;
    public Button Btn_Capsule;
    public Button Btn_Cylinder;

    // ������Ʈ ������ ���� ����
    public GameObject obj;

    // 

    // ��Ʈ ������ ��ġ������ ��� ���� ����
    public Transform root;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 1. �ش��ϴ� ����� ������Ʈ�� �����Ѵ�.
    // 2. �����ϴµ� �ʿ��� ������Ʈ�� ������ ������Ʈ���� ����(Mesh)�� ��� ������ �� �־�� �Ѵ�.
    // 3. ������ �� �ִ� ������ �������� ������Ʈ�� �����ϴ� �Լ��� �ʿ��ϴ�.
    // 4. �Լ��� ���ο��� �������� ������ �ٰž�.

    public void Create_Tetrahedron()
    {
        GameObject gameObject = Instantiate(obj, transform.position, Quaternion.identity, root);
        // gameObject.GetComponent<BlockHolder>()
    }
    public void Create_Hexahedron()
    {
        Instantiate(obj, transform.position, Quaternion.identity, root);
    }
    public void Create_Sphere()
    {
        Instantiate(obj, transform.position, Quaternion.identity, root);
    }
    public void Create_Capsule()
    {
        Instantiate(obj, transform.position, Quaternion.identity, root);
    }
    public void Create_Cylinder()
    {
        Instantiate(obj, transform.position, Quaternion.identity, root);
    }



}
