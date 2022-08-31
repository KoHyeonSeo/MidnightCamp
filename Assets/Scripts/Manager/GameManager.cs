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
    /// 현재 모드를 설정하는 Enum Type
    /// </summary>
    public enum Mode
    {
        Move,
        Rotate,
        Delete,
        ColorChange
    }

    /// <summary>
    /// 현재 모드
    /// </summary>
    public Mode curState = Mode.Move;

}
