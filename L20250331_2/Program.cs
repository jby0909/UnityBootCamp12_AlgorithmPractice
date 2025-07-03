namespace L20250331_2
{
    
    internal class Program
    {
        static void PrintNumber(int number)
        {
            if(number <= 0)
            {
                return;
            }
            PrintNumber(number - 1);
            Console.WriteLine(number);
            
        }

        static int N;
        static void Msg(int level)
        {
            //1."재귀함수가 뭔가요?"
            for(int i = 0; i < level * 4; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("\"재귀함수가 뭔가요?\"");
            //2.기저 조건 체크(level == N)
            if(level == N)
            {
                //2-1 조건 만족한다면 "재귀함수는~~~~~~"
                for (int i = 0; i < level * 4; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine("\"재귀함수는 자기 자신을 호출하는 함수라네\"");
                for (int i = 0; i < level * 4; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine("라고 답변하였지.");
                return;
            }

            //2-2 "잘들어~~ " 출력
            for (int i = 0; i < level * 4; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("\"잘 들어보게. 옛날옛날 한 산 꼭대기에 이세상 모든 지식을 통달한 선인이 있었어.");
            for (int i = 0; i < level * 4; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("마을 사람들은 모두 그 선인에게 수많은 질문을 했고, 모두 지혜롭게 대답해 주었지.");
            for (int i = 0; i < level * 4; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("그의 답은 대부분 옳았다고 하네. 그런데 어느 날, 그 선인에게 한 선비가 찾아와서 물었어.\"");

            // 재귀조건
            Msg(level + 1);

            //4. "라고 답변하였지"
            for (int i = 0; i < level * 4; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine("라고 답변하였지.");

        }

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            Console.WriteLine("어느 한 컴퓨터공학과 학생이 유명한 교수님을 찾아가 물었다.");
            Msg(0);

            

        }
        static int Fibo(int n)
        {
            if(n == 1)
            {
                return 1;
            }
            if(n == 2)
            {
                return 1;
            }

            return Fibo(n - 1) + Fibo(n - 2);
        }
        

        static void DrawLine(int lineCount)
        {
            if(lineCount <= 0)
            {
                return;
            }
            DrawLine(lineCount - 1);

            DrawStar(lineCount);
            Console.WriteLine();
        }

        static void DrawStar(int starCount)
        {
            if(starCount <= 0)
            {
                return;
            }

            DrawStar(starCount - 1);
            Console.Write('*');
        }

        static void OneToTen(int i)
        {
            //기저조건 : 끝내는 조건
            if (i > 10)
            {
                return;
            }
            Console.WriteLine(i);
            //재귀조건 : 자기자신을 호출하는 조건
            OneToTen(i + 1);
        }

        static void LeeJungKyun(int num)
        {
            Console.WriteLine(num);
            LeeJungKyun(num + 1);
        }
    }
}
