namespace L_20250428
{
    public partial class Program
    {
        //연결되지 않았다.
        const int INF = 987654321;

        private static int[][] graph;

        
        static void ConstructGraph()
        {
            graph = new int[7][];

            graph[0] = new int[] { 0, 7, INF, INF, 3, 10, INF };
            graph[1] = new int[] { 7, 0, 4, 10, 2, 6, INF };
            graph[2] = new int[] { INF, 4, 0, 2, INF, INF, INF };
            graph[3] = new int[] { INF, 10, 2, 0, 11, 9, 4 };
            graph[4] = new int[] { 3, 2, INF, 11, 0, INF, 5 };
            graph[5] = new int[] { 10, 6, INF, 9, INF, 0, INF };
            graph[6] = new int[] { INF, INF, INF, 4, 5, INF, 0 };
        }
        static void Main(string[] args)
        {
            ConstructGraph();

            int[] path;

            Console.WriteLine(GetDistance(0, 3, out path));

            Stack<int> stack = new Stack<int>();
            int current = 3;
            while (true)
            {
                if (path[current] == -1)
                {
                    break;
                }
                stack.Push(current);
                
                current = path[current];
                if (path[current] == current)
                {
                    stack.Push(current);
                    break;
                }
            }

            while(stack.Count > 0)
            {
                int pathNode = stack.Pop();
                Console.Write($"{pathNode} -> ");
            }


            //삽입할 때 우선순위를 항상 같이 저장함
            //MinHeap minHeap = new();

            //minHeap.Enqueue(5);
            //minHeap.Enqueue(4);
            //minHeap.Enqueue(3);
            //minHeap.Enqueue(2);
            //minHeap.Enqueue(1);

            //Console.WriteLine(minHeap.Peek());

            //Console.WriteLine(minHeap.Dequeue());
            //Console.WriteLine(minHeap.Dequeue());
            //Console.WriteLine(minHeap.Dequeue());
            //Console.WriteLine(minHeap.Dequeue());
            //Console.WriteLine(minHeap.Dequeue());
        }

        //GetDistance : 최단 거리를 구하는 함수
        //입력 : 시작정점, 도착정점
        //출력 : 최단거리
        const int NoWay = -1;
        static int GetDistance(int start, int end, out int[] path)
        {
            //1. start에서 다른 모든 정점까지의 거리를 저장할 배열을 만든다.
            int[] dist = new int[7];

            for(int i = 0; i < 7; i++)
            {
                dist[i] = INF;
            }
            dist[start] = 0;

            //path 배열을 생성하고 초기화 한다.
            path = new int[7];
            for(int i = 0; i < path.Length; i++)
            {
                path[i] = NoWay;
            }
            path[start] = start;

            //2. 방문하지 않은 정점 중 dist가 최소인 정점을 찾기 위한 우선순위 큐를 생성한다.
            PriorityQueue<int, int> pq = new();//<정점, dist>
            pq.Enqueue(start, dist[start]);

            //3. 모든 최단 경로를 찾을 때 까지 반복한다.
            while(pq.Count > 0)
            {
                //3-1.다음에 방문할 정점을 우선순위 큐에서 가져온다.
                int next = pq.Dequeue();

                //3-2. dist를 갱신한다.
                for (int v = 0; v < graph[next].Length; v++) // 연결된 정점만 살펴본다
                {
                    
                    int distViaNext = dist[next] + graph[next][v]; //start -> next -> v로 가는 최단 거리를 계산한다.

                    //최단 거리 비교한다.
                    //ㄴ start -> next -> v 가 더 짧다면 dist[v]를 갱신하고, pq에 삽입한다.
                    if(distViaNext < dist[v])
                    {
                        dist[v] = distViaNext;
                        pq.Enqueue(v, dist[v]);
                        path[v] = next;
                    }
                }
            }


            

            return dist[end];


        }
    }
}
