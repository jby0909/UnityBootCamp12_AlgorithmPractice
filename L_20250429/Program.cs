namespace L_20250429
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BSTree bsTree = new BSTree();
            bsTree.Insert(8);
            bsTree.Insert(3);
            bsTree.Insert(10);
            bsTree.Insert(1);
            bsTree.Insert(6);
            bsTree.Insert(14);

            bsTree.InorderSearch();
        }
    }

    class BSTree
    {
        private BSTreeNode? _root;

        //Insert : 새로운 데이터를 트리에 추가한다.
        //입력 : 새로운 정수 데이터
        //출력 : X
        public void Insert(int data)
        {
            //_root가 null인가?
            //ㄴ루트노드가 null이면 새로운 루트 노드를 만든다.
            if(_root == null)
            {
                _root = new BSTreeNode(data, null, this);
            }
            else
            {
                _root.Insert(data);
            }
            
        }

        //InorderSearch : 트리를 중위 순회한다.(내부에서 바로 출력)
        //입력 : X
        //출력 : X
        public void InorderSearch()
        {
            if(_root == null)
            {
                return;
            }

            _root.InorderSearch();

        }

        //LevelOrderSearch : 트리를 레벨 순회한다. (BFS??)
        // 입출력 X
        public void LevelOrderSearch()
        {
            if(_root == null)
            {
                return;
            }

            Queue<BSTreeNode> queue = new Queue<BSTreeNode>();
            queue.Enqueue(_root);

            while(queue.Count > 0)
            {
                BSTreeNode node = queue.Dequeue();
                Console.WriteLine($"{node.Data} ");

                if(node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if(node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }

        //Contains() : 주어진 데이터가 트리에 존재하는지 검사 한다.
        //입력 : 검사할 데이터(int)
        //출력 : 존재 여부(bool)
        public bool Contains(int data)
        {
            if(_root == null)
            {
                return false;
            }

           
            return _root.Contains(data);

        }

    }

    //Node
    //ㄴ데이터
    //ㄴ왼쪽자식노드
    //ㄴ오른쪽자식노드
    //ㄴ부모(선택)
    //ㄴ트리(선택)
    class BSTreeNode
    {
        public int Data { get; init; }
        public BSTreeNode Left { get; private set; }//왼쪽자식노드(나중에 수정 가능)
        public BSTreeNode? Right { get; private set; } //오른쪽자식노드(나중에 수정 가능)
        private BSTreeNode? _parent; //부모(생성할 때 받아야 함 : )
        private BSTree? _tree; //트리(생성할 때 받아야 함 : )

        public BSTreeNode(int data, BSTreeNode parent, BSTree tree)
        {
            Data = data;
            _parent = parent;
            _tree = tree;
        }
        
        //Insert : 새로운 데이터를 노드에 삽입한다. => 자신보다 작은값은 왼쪽에 삽입하고 큰값이면 오른쪽에 삽입한다.(같은값은??)
        //입력 : 새로운 정수 데이터
        //출력 : X
        public void Insert(int data)
        {
            if(data < Data)
            {
                if(Left == null)
                {
                    Left = new BSTreeNode(data, this, _tree);
                }
                else
                {
                    Left.Insert(data);
                }
            }
            else if(data > Data)
            {
                if(Right == null)
                {
                    Right = new BSTreeNode(data, this, _tree);

                }
                else
                {
                    Right.Insert(data);
                }
            }
        }

        public void InorderSearch()
        {
            
            if(Left != null)
            {
                Left.InorderSearch();   
            }

            Console.Write($"{Data} ");

            if(Right != null)
            {
                Right.InorderSearch();
            }

        }

        public bool Contains(int data)
        {
            if (Data == data)
            {
                return true;
            }
            else if (Data < data)
            {
                if (Left == null)
                {
                    return false;
                }
                return Left.Contains(data);
            }
            else
            {
                if (Right == null)
                {
                    return false;
                }
                return Right.Contains(data);
            }
           
        }
        

    }
}
