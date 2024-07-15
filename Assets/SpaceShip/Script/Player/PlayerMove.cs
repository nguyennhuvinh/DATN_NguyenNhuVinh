using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector2 difference = Vector2.zero;


    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    private float playerHalfWidth, playerHalfHeight;


    private void OnMouseDown()
    {
        if (GameController.Instance.currentState == GameState.PLAYING)
        {
            difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        }
    }

    private void OnMouseDrag()
    {
        if (GameController.Instance.currentState == GameState.PLAYING)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        }
    }



    private void Start()
    {


        mainCamera = Camera.main;
        SpriteRenderer playerRenderer = GetComponentInChildren<SpriteRenderer>();
        playerHalfWidth = playerRenderer.bounds.size.x / 2f;
        playerHalfHeight = playerRenderer.bounds.size.y / 2f;

        CalculateCameraBounds();
    }



    private void Update()
    {
        CheckLimitCam();
    }

    private void FixedUpdate()
    {

    }


    void CalculateCameraBounds()
    {
        if (mainCamera != null)
        {
            float cameraOrthographicSize = mainCamera.orthographicSize;
            float aspectRatio = Screen.width / (float)Screen.height;

            minX = mainCamera.transform.position.x - cameraOrthographicSize * aspectRatio;
            maxX = mainCamera.transform.position.x + cameraOrthographicSize * aspectRatio;
            minY = mainCamera.transform.position.y - cameraOrthographicSize;
            maxY = mainCamera.transform.position.y + cameraOrthographicSize;
        }
    }

    void CheckLimitCam()
    {
        
        Vector3 currentPosition = transform.position;


        currentPosition.x = Mathf.Clamp(currentPosition.x, minX + playerHalfWidth, maxX - playerHalfWidth);

  
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY + playerHalfHeight, maxY - playerHalfHeight);

       
        transform.position = currentPosition;

      
    }
    protected virtual void FireBullet()
    {

    }

}

