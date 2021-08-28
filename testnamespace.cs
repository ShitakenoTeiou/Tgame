using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace testnamespace
{
    public class testnamespace
    {
        //フィールドはここ
        private string name = "";
        private int age = 0;

        //コンストラクタ。オーバーロードしてるから二つある。
        public testnamespace() : this("名無し", 0)
        {
            Debug.Log("引数なしコンストラクタ");
        }

        public testnamespace(string name, int age)
        {
            this.name = name;
            this.age = age;
            Debug.Log("引数ありコンストラクタ" + name + age);
        }

        public void ShowAgeAndName()
        {
            Debug.Log(name + age);
        }

        public string Name
        {
            set
            {
                name = value;
            }

            get
            {
                return name;
            }
        }

        public int Age
        {
            set
            {
                age = value;
            }

            get
            {
                return age;
            }

        }
        

    }



}


