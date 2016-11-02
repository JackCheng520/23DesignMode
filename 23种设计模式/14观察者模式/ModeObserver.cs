using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeObserver  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/8 10:06:40
// ================================
namespace Assets.JackCheng._23种设计模式._14观察者模式
{
    public class ModeObserver : MonoBehaviour
    {
        Magazine m = new Magazine();
        Subscriber s = new Subscriber();

        void Start()
        {
            m.UpdateInfo();
        }
    }

    public delegate void Notify(object sender, NotifyArgs e);

    public class NotifyItem
    {
        public object receiver;

        public Notify notifyDelegate;
    }

    public class NotifyArgs
    {
        public int type;

        public List<object> paramlist;
    }

    public class NotifyType
    {
        public const int MAGAZINE_INFO_UPDATE = 0;
    }

    public class MessageCtrl
    {
        static Dictionary<int, List<NotifyItem>> dicNotifys;


        public static void Register(object receiver, int _type, Notify _notify)
        {

            if (dicNotifys == null)
                dicNotifys = new Dictionary<int, List<NotifyItem>>();

            NotifyItem item = new NotifyItem();
            item.receiver = receiver;

            if (!dicNotifys.ContainsKey(_type))
            {
                item.notifyDelegate += _notify;
                dicNotifys.Add(_type, new List<NotifyItem>() { item });
            }
            else
            {
                List<NotifyItem> items = dicNotifys[_type];

                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].receiver == receiver)
                    {
                        items[i].notifyDelegate += _notify;
                    }
                }
            }
        }

        public static void DisRegister(object receiver, int _type, Notify _notify)
        {
            List<NotifyItem> items;
            if (dicNotifys.ContainsKey(_type))
            {
                items = dicNotifys[_type];
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].receiver == receiver)
                    {
                        items[i].notifyDelegate -= _notify;
                    }
                }
                if (items.Count <= 0)
                    dicNotifys.Remove(_type);
            }
        }

        public static void SendMessage(int _type, params object[] args)
        {
            NotifyArgs e = null;
            if (args != null && args.Length > 0)
            {
                e = new NotifyArgs();
                for (int i = 0; i < args.Length; i++)
                {
                    e.type = _type;
                    e.paramlist.Add(args[i]);
                }
            }
            if (dicNotifys.ContainsKey(_type))
            {
                List<NotifyItem> items = dicNotifys[_type];
                for (int i = 0; i < items.Count; i++)
                {
                    items[i].notifyDelegate(null, e);
                }
            }
        }
    }

    //杂志
    public class Magazine
    {
        private string Name;
        public Magazine()
        {
            Name = "China Daily";
        }

        public void UpdateInfo()
        {
            MessageCtrl.SendMessage(NotifyType.MAGAZINE_INFO_UPDATE);
        }
    }

    //订阅者
    public class Subscriber
    {

        public Subscriber()
        {
            //MessageCtrl.Register(this, NotifyType.MAGAZINE_INFO_UPDATE, OnMagazineUpdate);
            //Debug.Log("--注册成功--");
        }
        ~Subscriber()
        {
            //MessageCtrl.DisRegister(this, NotifyType.MAGAZINE_INFO_UPDATE, OnMagazineUpdate);
            //Debug.Log("--注销成功--");
        }

        private void OnMagazineUpdate(object sender, NotifyArgs e)
        {
            Debug.Log("Magazine info is update");
        }

    }
}
