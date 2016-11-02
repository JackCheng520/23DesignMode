using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeFacade  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/7 13:31:18
// ================================
namespace Assets.JackCheng._23种设计模式._10外观模式
{
    public class ModeFacade : MonoBehaviour
    {
        void Start() {
            Consumer c = new Consumer("Jack");
            Facade facade = new Facade();

            facade.IsQualified(c);
        }
    }

    public class Consumer{
        public string Name;

        public Consumer(string  _name){
            Name = _name;
        }
    }

    public class Bank {
        public bool CheckHasSaving(Consumer c) 
        {
            Debug.Log("Check bank for " + c.Name);
            return true;
        }
    }

    public class Credit {
        public bool CheckGoodCredit(Consumer c) {
            Debug.Log("Check Credit for " + c.Name);
            return true;
        }
    }

    public class Loan {
        public bool CheckHasBadLoan(Consumer c) {
            Debug.Log("Check Loan for " + c.Name);
            return true;
        }
    }

    public class Facade {
        Bank bank = new Bank();
        Credit credit = new Credit();
        Loan loan = new Loan();

        public bool IsQualified(Consumer c) {
            return (bank.CheckHasSaving(c) &&
                    credit.CheckGoodCredit(c) &&
                    loan.CheckHasBadLoan(c));
        }
    }
}
