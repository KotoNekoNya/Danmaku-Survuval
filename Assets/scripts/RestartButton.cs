using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private void Start()
    {
        // �N�p�x�~�p���p�u�} �����~�{���y�� RestartScene() �~�p �����q�����y�u �~�p�w�p���y�� �{�~�����{�y
        GetComponent<Button>().onClick.AddListener(RestartScene);
    }

    private void RestartScene()
    {
        // �P���|�����p�u�} �y�~�t�u�{�� ���u�{�����u�z �p�{���y�r�~���z �����u�~��
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // �B���x���q�~���r�|���u�} �r���u�}�� �r �y�s���u
        Time.timeScale = 1; 

        // �P�u���u�x�p�s�����w�p�u�} �����u�~�� ���� �u�v �y�~�t�u�{����
        SceneManager.LoadScene(currentSceneIndex);
    }
}
