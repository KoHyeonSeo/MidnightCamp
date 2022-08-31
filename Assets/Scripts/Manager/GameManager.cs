using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// ���� ��带 �����ϴ� Enum Type
    /// </summary>
    public enum Mode
    {
        Move,
        Rotate,
        Delete,
        ColorChange
    }

    /// <summary>
    /// ���� ���
    /// </summary>
    public Mode curState = Mode.Move;

}
