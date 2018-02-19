using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace master
{
    public class BulletManager : MonoBehaviour
    {
        public List<GameObject> Mother = new List<GameObject>();
        // Use this for initialization

        void Start()
        {
            Mother = GetAllChildren.GetAll(gameObject);

        }

        // Update is called once per frame
        void Update()
        {
            int count = 0;
            foreach (GameObject g in Mother)
            {
                if (g == null)
                {
                    Mother.RemoveAt(count);
                }
                count++;
            }

            if (Mother.Count == 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public static class GetAllChildren

    {

        public static List<GameObject> GetAll(this GameObject obj)

        {

            List<GameObject> allChildren = new List<GameObject>();

            GetChildren(obj, ref allChildren);

            return allChildren;

        }



        //子要素を取得してリストに追加

        public static void GetChildren(GameObject obj, ref List<GameObject> allChildren)

        {

            Transform children = obj.GetComponentInChildren<Transform>();

            //子要素がいなければ終了

            if (children.childCount == 0)
            {

                return;

            }

            foreach (Transform ob in children)
            {
                allChildren.Add(ob.gameObject);
                GetChildren(ob.gameObject, ref allChildren);
            }
        }
    }
}