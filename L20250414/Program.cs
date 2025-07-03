using System.Text;

namespace L20250414
{
    class CustomStack
    {
        //데이터
        int[] _container = new int[10004];
        int top = -1;
        int size = 0;

        //메소드
        public void Push(int x)
        {
            top++; // SoC
            _container[top] = x;
            size++;
        }

        public const int NO_DATA = -1;
        public int Pop()
        {
            if(top == NO_DATA)
            {
                return NO_DATA;
            }
            size--;
            return _container[top--];
           
        }

        public int Size()
        {
            return size;
        }

        public int Empty()
        {
            return (size == 0) ? 1 : 0;
            
        }

        public int Top()
        {
            if(size == 0)
            {
                return -1;
            }

            return _container[top];
        }


    }

    //모듈은 하나의 책임만 가져야 한다.
    //SRP ( single responsibility principle)

    internal class Program
    {
        public static StringBuilder sb10828 = new StringBuilder();
        static int N;
        static CustomStack st = new();
        static void Main(string[] args)
        {
                
            N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0].CompareTo("push") == 0)
                {
                    int x = int.Parse(commands[1]);
                    st.Push(x);
                }
                else if (commands[0].CompareTo("pop") == 0)
                {
                    sb10828.AppendLine(st.Pop().ToString());

                }
                else if (commands[0].CompareTo("size") == 0)
                {
                    sb10828.AppendLine(st.Size().ToString());
                }
                else if (commands[0].CompareTo("empty") == 0)
                {
                    sb10828.AppendLine(st.Empty().ToString());
                    
                }
                else if (commands[0].CompareTo("top") == 0)
                {
                    sb10828.AppendLine(st.Top().ToString());
                }
            }

            Console.WriteLine(sb10828.ToString());


        }

        public static void BJ10828_Arr()
        {
            int[] myStack = new int[10000];
            int top = 0;

            int commandCount = int.Parse(Console.ReadLine());

            List<int> answer = new List<int>();

            for (int i = 0; i < commandCount; i++)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0].CompareTo("push") == 0)
                {
                    myStack[top] = int.Parse(commands[1]);
                    top++;
                }
                else if (commands[0].CompareTo("pop") == 0)
                {
                    if (top > 0)
                    {
                        top--;
                        answer.Add(myStack[top]);
                        //Console.WriteLine(myStack[top - 1].ToString());
                        sb10828.AppendLine(myStack[top].ToString());

                    }
                    else
                    {
                        answer.Add(-1);
                    }

                }
                else if (commands[0].CompareTo("size") == 0)
                {
                    answer.Add(top);
                    //Console.WriteLine((top + 1).ToString());
                    sb10828.AppendLine(top.ToString());

                }
                else if (commands[0].CompareTo("empty") == 0)
                {
                    if (top == 0)
                    {
                        answer.Add(1);
                        sb10828.AppendLine("1");
                    }
                    else
                    {
                        answer.Add(0);
                        sb10828.AppendLine("0");
                    }
                }
                else if (commands[0].CompareTo("top") == 0)
                {
                    if ((top - 1) < 0)
                    {
                        answer.Add(-1);
                        sb10828.AppendLine("-1");
                    }
                    else
                    {
                        answer.Add(myStack[top - 1]);
                        sb10828.AppendLine(myStack[top - 1].ToString());

                    }
                }
            }


            //foreach(int a in answer)
            //{
            //    Console.WriteLine(a);
            //}
            Console.WriteLine(sb10828.ToString());

        }
    }
}
