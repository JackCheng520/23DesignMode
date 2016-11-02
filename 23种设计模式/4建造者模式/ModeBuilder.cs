using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeBuilder  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/6 14:23:37
// ================================
namespace Assets.JackCheng._23种设计模式._4建造者模式
{
    public class ModeBuilder : MonoBehaviour
    {
        Director director = new Director();

        void Start() {
            director.Build(new BuilderLi());

            director.Build(new BuilderWang());
        }
    }

    public class House
    {
        public IList<string> listPart = new List<string>();

        public void Add(string name) 
        {
            listPart.Add(name);
        }

        public void Appear() 
        {
            Debug.Log("--开始建造房子--");
            for (int i = 0; i < listPart.Count; i++) {
                Debug.Log("建造房子中 -- "+listPart[i]);
            }
            Debug.Log("--结束建造房子--");
        }
    }

    public class Director {

        public void Build(Builder b) {
            b.BuildDoor();
            b.BuildWindow();
            Debug.Log(b.builderName);
            b.GetHouse().Appear();
        }
    }

    public abstract class Builder {
        public House house;
        public Builder() {
            house = new House();
        }

        public Builder(string name) {
            house = new House();
            builderName = name;
        }

        public string builderName;
        public abstract void BuildDoor();

        public abstract void BuildWindow();

        public abstract House GetHouse();
    }

    public class BuilderLi : Builder 
    {
        public BuilderLi() : base("li") { }
        public override void BuildDoor()
        {
            house.Add("门");
        }

        public override void BuildWindow()
        {
            house.Add("窗");
        }

        public override House GetHouse() {
            return house;
        }
    }

    public class BuilderWang : Builder {

        public BuilderWang() : base("wang") { }
        public override void BuildDoor()
        {
            house.Add("门");
        }

        public override void BuildWindow()
        {
            house.Add("窗");
        }

        public override House GetHouse()
        {
            return house;
        }
    }


}
