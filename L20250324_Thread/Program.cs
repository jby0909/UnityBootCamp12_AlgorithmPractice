using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L20250324_Thread
{
    internal class Program
    {
        static Object _lock = new Object(); // 동기화 객체
        static SpinLock spinLock = new SpinLock();
        
        //atomic, 공유영역 작업은 원자성, 중간에 끊지 못하게 하는 것 
        volatile static int Money = 0; //volatile 최적화 하지 못하게 막음(컴파일러가 최적화하면서 순서가 바뀔 수 있어서 문제가 생길 수 있음) -> C#에서는 잘 안씀(C언어에서만 사용)

        static bool lockTaken = false;

        static void Add()
        {
            int Gold = 0;
            for (int i = 0; i < 1000000; ++i)
            {
                //원자성을 지키는 코드 => 이 문법이 더 가벼워서 빠름
                Interlocked.Increment(ref Money); // 해당 변수가 증가하는 중간에 다른 작업으로 빠지지 않도록 강제함(이 작업이 끝날때까지는 다른 스레드에게 넘겨주지 않음)

                //원자성을 기본으로 지킴 => 이 문법을 사용할 경우도 많음
                //lock (_lock) // 중간에 다른 작업으로 나가더라도 해당 문(_lock)이 잠겨있는지 확인 후 잠겨있지 않으면 작업 > 잠겨있으면 기다렸다가 다시 돌아감 
                //{
                //    Money++;
                //    //int temp = Money;
                //    //temp = temp + 1;
                //    //Money = temp;
                //}


                //위의 lock(){} 쓰는것과 같은 결과. 위의 코드가 더 간단하고 직관적이라 더 많이 쓰임
                spinLock.Enter(ref lockTaken);
                
                Money++;
                spinLock.Exit();
                

                Gold++;
            }
        }

        static void Remove()
        {
            Interlocked.Decrement(ref Money); // 해당 변수가 감소하는 중간에 다른 작업으로 빠지지 않도록 강제함
            //for (int i = 0; i < 1000000; ++i)
            //{
            //    lock (_lock)
            //    {
            //        Money--;
            //    }
            //}
        }

        //foreground, main thread 종료 되면 나머지 쓰레드는 다 종료
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(Add));
            Thread thread2 = new Thread(new ThreadStart(Remove));

            //B함수 따로 실행 시켜줘 (Thread) -> OS 부탁
            thread1.IsBackground = true;
            thread1.Start();
            thread2.IsBackground = true;
            thread2.Start();


            thread1.Join();
            thread2.Join();


            Console.WriteLine(Money);
        }
    }
}
