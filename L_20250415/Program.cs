namespace L_20250415
{
    //불변식(Invariant) : 클래스의 데이터 멤버에 대한 조건식 : 생성자에 나타남
    public struct Edge
    {
        //init 과 private set은 다르다 => init은 생성할 때 딱 한번만 지정가능함을 의미. private set은 내부에서 바꿀 수 있음.
        public int Next { get; init; }
        public int Weight { get; init; }

        public Edge(int next, int weight)
        {
            Next = next;
            Weight = weight;
        }
    }

    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<int>[] neighbors = new List<int>[7];
            for(int i = 0; i < neighbors.Length; i++)
            {
                neighbors[i] = new List<int>();
            }
            //인접리스트로 그래프 구성
            #region 그래프 구성
            neighbors[0].Add(1);

            neighbors[1].Add(0);
            neighbors[1].Add(2);
            neighbors[1].Add(3);
            
            neighbors[2].Add(1);
            neighbors[2].Add(5);
            neighbors[2].Add(6);
            
            neighbors[3].Add(1);
            neighbors[3].Add(4);
            neighbors[3].Add(5);
            
            neighbors[4].Add(3);
            
            neighbors[5].Add(2);
            neighbors[5].Add(3);
            
            neighbors[6].Add(2);
            #endregion


            #region 깊이 우선 탐색
            //1.방문한 정점을 기록할 집합을 만든다.
            //각 정점마다 방문 여부를 기록
            bool[] isVisited = new bool[7];
            //방문했다/안했다 -> bool

            //2.스택을 생성한다.
            Stack<int> st = new Stack<int>();
            st.Push(0);

            //3.모든 정점을 방문할 때 까지 반복한다.
            while(st.Count > 0)
            {
                //3-1. 다음에 방문할 정점을 가져온다.
                int vertexTovisit = st.Pop();


                if (isVisited[vertexTovisit])
                {
                    continue;
                }

                //3-2. 방문 여부를 기록한다.
                Console.Write($"{vertexTovisit}->");
                isVisited[vertexTovisit] = true;

                //3-3. 주변노드를 방문한다.
                for (int i = neighbors[vertexTovisit].Count - 1; i >= 0; i--)
                {
                    //방문하지 않은 정점만 스택에 추가
                    if (!isVisited[neighbors[vertexTovisit][i]])
                    {
                        st.Push(neighbors[vertexTovisit][i]);
                    }
                }
               
            }


            #endregion

            #region 너비 우선 탐색
            //1.방문한 정점을 기록할 집합을 만든다.
            //각 정점마다 방문 여부를 기록
            bool[] isVisited2 = new bool[7];
            //방문했다/안했다 -> bool

            //2.스택을 생성한다.
            Queue<int> q = new Queue<int>();
            q.Enqueue(0);

            //3.모든 정점을 방문할 때 가지 반복한다.
            while (q.Count > 0)
            {
                //3-1. 다음에 방문할 정점을 가져온다.
                int vertexTovisit = q.Dequeue();


                if (isVisited2[vertexTovisit])
                {
                    continue;
                }

                //3-2. 방문 여부를 기록한다.
                Console.Write($"{vertexTovisit}->");
                isVisited2[vertexTovisit] = true;

                //3-3. 주변노드를 방문한다.
                foreach (int neighbor in neighbors[vertexTovisit])
                {
                    //방문하지 않은 정점만 스택에 추가
                    if (!isVisited2[neighbor])
                    {
                        q.Enqueue(neighbor);
                    }
                }
                
            }
            #endregion

            #region 깊이 우선 탐색(재귀)
            Console.WriteLine("\n----------------------------");
            bool[] isVisited3 = new bool[7];
            Dfs(0, isVisited3, neighbors);
            #endregion
        }

        //정점을 방문하는 일
        static void Dfs(int vertexTovisit, bool[] isVisited, List<int>[] neighbors)
        {
            if (isVisited[vertexTovisit])
            {
                return;
            }

            //3-2. 방문 여부를 기록한다.
            Console.Write($"{vertexTovisit}->");
            isVisited[vertexTovisit] = true;

            //3-3. 주변노드를 방문한다.
            foreach(int neighbor in neighbors[vertexTovisit])
            {
                //방문하지 않은 정점만 스택에 추가
                if (!isVisited[neighbor])
                {
                    Dfs(neighbor,isVisited,neighbors);
                }
            }
        }
    }
}
