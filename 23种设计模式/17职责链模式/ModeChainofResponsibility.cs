using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeChainofResponsibility  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/8 14:16:16
// ================================
namespace Assets.JackCheng._23种设计模式._17职责链模式
{
    public class ModeChainofResponsibility : MonoBehaviour
    {
        

        void Start() {

            PurchaseRequest pr = new PurchaseRequest(1200000, "新程序员工资");

            Position chief = new Chief();
            Position vicepresident = new VicePresident();
            Position president = new President();

            chief.nextPosition = vicepresident;
            vicepresident.nextPosition = president;

            chief.Handle(pr);
        }

    }

    public class PurchaseRequest {
        public int Money;

        public string Name;

        public PurchaseRequest(int _money, string _name) {
            Money = _money;
            Name = _name;
        }
    }

    public abstract class Position  {
        public Position nextPosition;

        public abstract void Handle(PurchaseRequest pr);
    }

    public class Chief : Position {
        public override void Handle(PurchaseRequest pr)
        {
            if (pr.Money < 10000)
                Debug.Log("总监同意购买");
            else
            {
                Debug.Log("总监权利不够，交由副总处理");
                nextPosition.Handle(pr);
            }
        }
    }

    public class VicePresident : Position
    {
        public override void Handle(PurchaseRequest pr)
        {
            if (pr.Money >= 10000 && pr.Money < 100000)
                Debug.Log("副总同意购买");
            else
            {
                Debug.Log("副总权利不够，交由老板处理");
                nextPosition.Handle(pr);
            }
        }
    }

    public class President : Position
    {
        public override void Handle(PurchaseRequest pr)
        {
            if (pr.Money >= 100000 )
                Debug.Log("老板同意购买");
        }
    }
}














