using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoodController : MonoBehaviour
{
    #region attributes

    private bool _isDragging;
    private Vector3 _newPoint;
    private Vector3 _oldPoint;
    private float _predictedTime;
    private DateTime _startDate;

    #endregion

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > GameManager.ScreenBound.x)
        {
            ScoreController.MistakesCount--;
            Destroy(gameObject);
        }

        if (gameObject.transform.position.y > GameManager.ScreenBound.y)
        {
            if (GetComponent<AssemblyTypeComponent>().Type ==
                transform.parent.gameObject.GetComponent<AssemblyTypeComponent>().Type)
            {
                ScoreController.Score++;
            }
            else
            {
                ScoreController.MistakesCount--;
            }

            Destroy(gameObject);
        }


        if (_isDragging)
        {
            Vector2 tempPoint = CameraManager.Instance.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(tempPoint.x, tempPoint.y, -1);
        }
    }

    void OnMouseDown()
    {
        if (transform.parent.GetComponent<AssemblyTypeComponent>() != null)
            return;

        _oldPoint = transform.position;
        _predictedTime = Vector3.Distance(CameraManager.Instance.ScreenToWorldPoint(transform.position),
            GameManager.ScreenBound) / 0.5f;
        _startDate = DateTime.Now;
        _isDragging = true;
    }

    private void OnMouseUp()
    {
        if (!_isDragging)
            return;

        _isDragging = false;
        Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(transform.position,
            0.05f).Where(collider => collider.gameObject.GetComponent<AssemblyTypeComponent>() != null).ToArray();

        float minDistance = Single.MaxValue;
        GameObject newParent = null;

        if (overlappingColliders.Length == 1)
        {
            AttemptToReturn();
            return;
        }

        foreach (Collider2D collider2D in overlappingColliders)
        {
            float distanceTmp =
                Vector2.Distance(collider2D.gameObject.transform.position, gameObject.transform.position);
            if (distanceTmp < minDistance &&
                !ReferenceEquals(collider2D.gameObject, gameObject) &&
                collider2D.gameObject.GetComponent<AssemblyTypeComponent>() != null)
            {
                minDistance = distanceTmp;
                newParent = collider2D.gameObject;
            }
        }

        if (newParent != null && newParent.transform.childCount == 0)
        {
            gameObject.transform.SetParent(newParent.transform);
            gameObject.transform.position = new Vector3(newParent.transform.position.x, newParent.transform.position.y,
                newParent.transform.position.z - 1);
        }
        else
        {
            AttemptToReturn();
        }
    }

    void AttemptToReturn()
    {
        DateTime endDate = DateTime.Now;

        if ((endDate - _startDate).Milliseconds/100f < _predictedTime)
        {
            transform.position = _oldPoint;
            return;
        }

        ScoreController.MistakesCount--;
    }
}