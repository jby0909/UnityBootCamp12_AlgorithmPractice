namespace L20250408
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lst = new();
            lst.Add(1);
            lst.Add(3);
            lst.Add(3);
            lst.Add(7);
            lst.Add(7);
            lst.Add(9);

            Console.WriteLine(UpperBound(lst, 7));
            Console.WriteLine(LowerBound(lst, 5));

            
        }

        public static bool LinearSerach(List<int> lst, int key)
        {
            foreach(int elem in lst)
            {
                if(elem == key)
                {
                    return true;
                }

            }
            return false;
        }

        //public static bool MyBinarySearch(List<int> lst, int key)
        //{
        //    //반복 탈출 조건 : (1) lst에서 key를 찾았거나 (2)lst 전체를 순회할 때까지

        //    //1.주어진 검색 범위에서 중간값을 찾는다
        //    //검색범위 : 리스트의 길이(int)?, 인덱스 번호(int)
        //    int length = lst.Count;
        //    int index = length / 2;

        //    //2. 중간값과 key를 비교한다.
        //    //2-1 key < 중간값 ==> 검색 범위를 줄인다(왼쪽)
        //    if (lst[index] > key)
        //    {
        //        length /= 2;
        //        index -= (length / 2);
        //    }
        //    //2-2 key == 중간값 ==>찾았다
        //    else if (lst[index] == key)
        //    {
        //        return true;
        //    }
        //    //2-3 key > 중간값 ==> 검색 범위를 줄인다(오른쪽)
        //    else if (lst[index] < key)
        //    {
        //        length /= 2;
        //        index += length / 2;
        //    }
        //}

        //public static bool BinarySearch(List<int> lst, int key)
        //{
        //    //반복 탈출 조건 : (1) lst에서 key를 찾았거나 (2)lst 전체를 순회할 때까지

        //    //1.주어진 검색 범위에서 중간값을 찾는다
        //    //검색범위 [시작index : 끝index]
        //    //          left         right
        //    int left = 0;
        //    int right = lst.Count - 1;

        //    while(left <= right) // 유효범위 체크 left <= right
        //    {
        //        //중간값
        //        int mid = (left + right) / 2; //오버플로우 가능성이 있음
        //        // left + (right - left) * 0.5; //오버플로우 일어나지 않는 식

        //        //2. 중간값과 key를 비교한다.
        //        //2-1 key < 중간값 ==> 검색 범위를 줄인다(왼쪽)
        //        if (lst[mid] > key)
        //        {
        //            right = mid - 1;

        //        }
        //        //2-2 key == 중간값 ==>찾았다
        //        else if (lst[mid] == key)
        //        {
        //            return true;
        //        }
        //        //2-3 key > 중간값 ==> 검색 범위를 줄인다(오른쪽)
        //        else if (lst[mid] < key)
        //        {
        //            left = mid + 1;
        //        }
        //    }
        //}

        //lst에서 key보다 크가나 같은 첫번째 원소의 인덱스를 반환
        public static int LowerBound(List<int> lst, int key)
        {
            //데이터 범위[start, end)
            int start = 0;
            int end = lst.Count;

            int result = -1;

            while(start < end)
            {
                int mid = (start + end) / 2;
                if (lst[mid] >= key)
                {
                    end = mid;
                    result = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return result;
        }

        //key보다 큰 첫번째 원소
        public static int UpperBound(List<int> lst, int key)
        {
            //데이터 범위[start, end)
            int start = 0;
            int end = lst.Count;
            int result = -1;
            while(start < end)
            {
                int mid = (start + end) / 2;

                //key와 같거나 => 검색범위를 오른쪽으로 옮긴다.
                //key보다 작거나 => 검색범위를 오른쪽으로 옮긴다.
                if (lst[mid] <= key)
                {
                    start = mid + 1;
                }
                //key보다 크거나 => 검색범위를 왼쪽으로 옮기고 정답 후보를 등록한다.
                else
                {
                    end = mid;
                    result = mid;
                }
            }
            return result;
        }

    }
}
