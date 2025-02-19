using System;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 필요

public class BlockArea : MonoBehaviour
{
    private bool isPlayerInside = false; // 플레이어가 영역 안에 있는지 확인하는 변수
    public String SceneName;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInside = true;
            Debug.Log("player In");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // "Player" 태그를 가진 오브젝트가 나갔을 때
        {
            isPlayerInside = false;
            Debug.Log("Player left the area.");
        }
    }

    void Update()
    {
        if(isPlayerInside == true && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
