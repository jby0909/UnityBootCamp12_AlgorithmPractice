using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_20250428
{
    public class MinHeap
    {
        //완전 이진 트리를 배열로 구현
        private List<int> _tree = new();
        //트리를 배열로 구현 => 모든 노드의 정보가 배열에 표현 =>  배열의 각원소는 인덱스를 이용해 접근 => 내자식을 찾아가려면 인덱스를 알면 됨

        //Peek : 최소 원소를 반환
        //입력 :  X
        //출력 : 최소 원소(루트 노드의 값) => 0번
        public int Peek()
        {
            return _tree[0];
        }

        //Enqueue : 힙에 원소를 삽입
        //입력 : 새로운 데이터
        //출력 : X
        //예외 : 중복된 데이터가 들어온다면? => 중복 허용
        public void Enqueue(int newValue)
        {
            //1. 맨 끝에 새로운 데이터 삽입
            _tree.Add(newValue);
            //2.힙의 불변성이 지켜질 때 까지
            // ㄴ2.1 부모와 자식을 비교하여 바꾼다 => if(자식 < 부모) 자식과 부모 바꾼다
            int childIndex = _tree.Count;
            while(childIndex != 1) //새로운 데이터가 삽입된 노드의 모든 조상 노드를 탐색할 때까지
            {
                int parentIndex = childIndex / 2;
                
                if (_tree[parentIndex - 1] > _tree[childIndex - 1])
                {
                    int temp = _tree[parentIndex - 1];
                    _tree[parentIndex - 1] = _tree[childIndex - 1];
                    _tree[childIndex - 1] = temp;
                }

                childIndex = parentIndex;

            }
           
        }


        //Dequeue : 힙에서 원소를 삭제
        //입력 : 없은
        //출력 : 삭제된 데이터 => 최소 원소 => 루트 노드
        public int Dequeue()
        {
            //1.힙에서 루트노드 삭제
            int result = _tree[0];

            //2.마지막 원소를 루트 노드로 이동시킨다.
            _tree[0] = _tree[_tree.Count - 1];
            //마지막 원소를 지우는것......Remove?
            _tree.RemoveAt(_tree.Count - 1);

            //3.힙의 불변성을 만족할 때까지
            //ㄴ3.1 부모와 두 자식 중 최솟값과 교환한다.
            int current = 1;
            while(current * 2 < _tree.Count)
            {
                int leftChild = current * 2;
                int rightChild = current * 2 + 1;
                int child = leftChild;
                if (rightChild < _tree.Count && _tree[rightChild - 1] < _tree[leftChild - 1])
                {
                    child = rightChild;
                }
                if (_tree[current - 1] < _tree[child - 1])
                {
                    break;
                }
                int temp = _tree[current - 1];
                _tree[current - 1] = _tree[child - 1];
                _tree[child - 1] = temp;
                current = child;
            }

            //4.삭제한 원소를 반환한다. 
            return result;
        }

        private void Swap(ref int lhs, ref int rhs)
        {
            int temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
