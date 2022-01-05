using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private GameObject textLoading; // �ε� �ؽ�Ʈ ������Ʈ
    [SerializeField]
    private GameObject plain; // ����� ������Ʈ
    void Start()
    {
        // �ε� �ؽ�Ʈ ��Ȱ��ȭ
        textLoading.SetActive(false);
    }
    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "StartBtn":
                Bullet.score = 0;
                plain.SetActive(false);
                textLoading.SetActive(true);
                Invoke("LoadGameScene", 5);
                break;
            case "LeaderBoardBtn":
                LoadBoardScene();
                break;
            case "HelpBtn":
                LoadHelpScene();
                break;
            case "ExitBtn":
                LoadExitScene();
                break;
        }
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    private void LoadBoardScene()
    {
        SceneManager.LoadScene("LeaderBoardScene");
    }
    private void LoadHelpScene()
    {
        SceneManager.LoadScene("HelpScene");
    }
    private void LoadExitScene()
    {
        Application.Quit();
    }
}