using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization

    private static GameManager s_instance;
    #region Public Properties

    public static GameManager Instance
    {
        get
        {
            return s_instance;
        }
    }
    #endregion

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        s_instance = this;
    }

    private void OnDestroy()
    {
        s_instance = null;
    }

}
