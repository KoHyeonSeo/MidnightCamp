using System.Collections;
using System.Collections.Generic;
using System.Linq; // 추가
using UnityEngine;

// 1. "Root"(혹은 "Object")로부터 모든 자식까지의 벡터를 구한다
// 2. 구한 벡터를 정렬하여 최대/최소 X, Y, Z값을 구한다(더 정확하려면 그들의 scale값까지 구해야하지만 일단은 pivot을 기준으로 ..^^)
// 3. X, Y에 대해서는 최대&최소의 평균값에 위치하도록, Z에 대해서는 최대값에서 일정 거리만큼 떨어진 곳에 위치하도록 카메라 배치(이것은 3D & 2D씬에서)

public class LHE_CalculateMaxDistance : MonoBehaviour
{
    // 부모오브젝트인 Root 찾기
    GameObject root;

    // List 선언
    List<Vector3> toChildVector = new List<Vector3>();
    List<float> toChildX = new List<float>();
    List<float> toChildY = new List<float>();
    List<float> toChildZ = new List<float>();

    // X, Y의 Max<->Min 평균값
    public float averageX;
    public float averageY;
    public float averageZ;
    // Z의 Max값
    public float maxZ;
    public float maxY;
    public float minX;


    public static LHE_CalculateMaxDistance Instance;
    private void Awake()
    {
        // 만약에 Instance가 null이라면
        if (Instance == null)
        {
            // Instance에 나를 넣겠다
            Instance = this;
            // Scene이 전환되어도 나를 파괴되지 않게 하겠다
            DontDestroyOnLoad(gameObject);
        }
        // 그렇지 않으면(이전에 만들어 놓은 애가 있다면)
        else
        {
            // 나를 파괴하겠다
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        root = GameObject.Find("Root");
        //print("childcount " + root.transform.childCount); // 6 정상 반환

        //for(int i = 0; i < root.transform.childCount; i++)
        //{
        //    toChildVector.Add(root.transform.GetChild(i).gameObject.transform.position - root.transform.position);
        //    print(toChildVector[i]); // 6개 벡터 정상 반환

        //}

        for (int i = 0; i < root.transform.childCount; i++)
        {
            toChildX.Add((root.transform.GetChild(i).gameObject.transform.position - root.transform.position).x);
            toChildY.Add((root.transform.GetChild(i).gameObject.transform.position - root.transform.position).y);
            toChildZ.Add((root.transform.GetChild(i).gameObject.transform.position - root.transform.position).z);

            //print(toChildX[i]); // 정상출력
            //print(toChildY[i]); // 정상출력
            //print(toChildZ[i]); // 정상출력
        }

        //print(toChildX.Max()); // 정상출력
        //print(toChildX.Min()); // 정상출력

        // X, Y의 Max<->Min 평균값
        averageX = (toChildX.Max() + toChildX.Min()) / 2;
        averageY = (toChildY.Max() + toChildY.Min()) / 2;
        averageZ = (toChildZ.Max() + toChildZ.Min()) / 2;
        //print("averageX " + averageX); // 정상출력
        //print("averageY " + averageY); // 정상출력

        // Z의 Max값
        maxZ = toChildZ.Max();
        maxY = toChildY.Max();
        minX = toChildX.Min();
        //print("maxZ " + maxZ); // 정상출력
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
