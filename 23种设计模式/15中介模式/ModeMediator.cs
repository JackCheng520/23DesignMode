using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：ModeMediator  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/9/8 11:35:33
// ================================
namespace Assets.JackCheng._23种设计模式._15中介模式
{
    public class ModeMediator : MonoBehaviour
    {
        void Start() {
            BasePlayer a = new PlayerA();
            BasePlayer b = new PlayerA();



            BaseMediator m = new Mediator(new InitState());

            m.Enter(a);
            m.Enter(b);

            m.state = new AWinState(m);
            m.ChangeMoney(5);

            m.state = new BWinState(m);
            m.ChangeMoney(10);


        }
    }
    //======================玩家=========================//
    public abstract class BasePlayer {
        protected int money;

        public abstract void AddMoney(int count);

        public abstract void ReduceMoney(int count);
    }

    public class PlayerA : BasePlayer {
        public override void AddMoney(int count)
        {
            money += count;
            Debug.Log("Player A Money Change count :" + count + "money:" + money);
        }

        public override void ReduceMoney(int count)
        {
            money -= count;
            Debug.Log("Player A Money Change count :" + count + "money:" + money);
        }
    }

    public class PlayerB : BasePlayer {
        public override void AddMoney(int count)
        {
            money += count;
            Debug.Log("Player A Money Change count :" + count + "money:" + money);
        }

        public override void ReduceMoney(int count)
        {
            money -= count;
            Debug.Log("Player A Money Change count :" + count + "money:" + money);
        }
    }

    //======================状态=========================//
    public abstract class State {
        public BaseMediator mediator;
        public abstract void ChangeMoney(int count);
    }

    public class AWinState : State{
        public AWinState(BaseMediator _mediator) {
            mediator = _mediator;
        }
        public override void ChangeMoney(int count)
        {
            for (int i = 0; i < mediator.listPlayer.Count; i++) {
                if (mediator.listPlayer[i] is PlayerA) {
                    mediator.listPlayer[i].AddMoney(count);
                }
            }

        }
    }

    public class BWinState : State {
        public BWinState(BaseMediator _mediator) {
            mediator = _mediator;
        }
        public override void ChangeMoney(int count)
        {
            for (int i = 0; i < mediator.listPlayer.Count; i++)
            {
                if (mediator.listPlayer[i] is PlayerB)
                {
                    mediator.listPlayer[i].AddMoney(count);
                }
            }
        }
    }

    public class InitState : State {

        public InitState() {
            Debug.Log("游戏初始化----");
        }
        public override void ChangeMoney(int count)
        {

        }
    }

    //======================中介=========================//

    public abstract class BaseMediator {
        public List<BasePlayer> listPlayer;

        public State state;
        public BaseMediator(State _state) {
            listPlayer = new List<BasePlayer>();
            state = _state;
        }


        public abstract void Enter(BasePlayer p);

        public abstract void Exit(BasePlayer p);

        public abstract void ChangeMoney(int count);
    }

    public class Mediator :BaseMediator {
        public Mediator(State _state) : base(_state) { }

        public override void Enter(BasePlayer p)
        {
            listPlayer.Add(p);
        }

        public override void Exit(BasePlayer p)
        {
            listPlayer.Remove(p);
        }

        public override void ChangeMoney(int count)
        {
            state.ChangeMoney(count);
        }
    }
}
