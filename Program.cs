using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan_CTDL_GT_PA2
{
    class Program
    {
        static void PrintArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i].ToString() + " ");
            }
            Console.WriteLine("");
        }
        static int[] ReadArrayHex()
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("Bài tập cuối kỳ Cấu trúc dữ liệu & Giải thuật");
            Console.WriteLine("*********************************************");
            Console.WriteLine("");
            Console.WriteLine("Nhập vào số lượng phần tử trong mảng rồi sau đó nhập phần tử: ");
            string s = Console.ReadLine();

            //gọi convert.toint32 để chuyển giá trị thập lục phân thành thập phân
            int n = Convert.ToInt32(s, 16);
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                s = Console.ReadLine();
                array[i] = Convert.ToInt32(s, 16);

            }
            Console.WriteLine("Bạn đã nhập vào mảng có {0} phần tử", array.Length);


            return array;
        }

        static void selectionSort(int[] array)
        {

            int n = array.Length;
            //khởi gán i = 0

            for (int i = 0; i < n; i++)
            {
                //Đi tìm phần tử nhỏ nhất thứ i để đưa về vị trí
                //Giả sử i là phần tử nhỏ nhất i = min
                int minIndex = i;
                for (int j = i; j < n; j++)
                {
                    //nếu giá trị tại a[min] còn lớn hơn a[i] -> cập nhật lại j
                    if (array[minIndex] > array[j])
                    {
                        minIndex = j;
                    }
                }
                //Đã tìm được phần tử nhỏ nhất
                //Hoán vị về vị trí i nếu min khác i
                if (minIndex != i)
                {
                    int temp = array[minIndex];
                    array[minIndex] = array[i];
                    array[i] = temp;
                }

            }
            StreamWriter filePath = new StreamWriter("C:\\Users\\Linewbie\\source\\repos\\Test_Queue_Doan\\writeHexNumbers.txt");
            foreach (var hex in array)
            {
                //Convert số nguyên sang hexadecimal sau đó xuất ra tập tin
                filePath.WriteLine(hex.ToString("X"));
            }
            filePath.Close();
        }

        static int binarySearch(int[] array, int x)
        {

            int left = 0;// dat left o phan tu dau tien cua mang
            int right = array.Length - 1;//right o phan tu n-1

            while (left <= right)
            {
                //tim phan tu mid o giua mang
                var mid = (left + right) / 2;
                //neu x = mid thi tra ve ket qua da tim thay x tai mid
                if (array[mid] == x)
                {
                    return mid;
                }
                //neu x can tim be hon mid thi gan right = mid - 1;
                if (x < array[mid])
                {
                    right = mid - 1;
                }
                //Nguoc lai neu x > mid thi left = mid + 1
                else
                    left = mid + 1;
            }
            Console.WriteLine("Không tìm thấy x");
            //neu khong tim thay phan tu nao thi tra kq ve -1
            return -1;
        }

        public static void TachSoChanLe(int[] array)
        {
            Queue s3 = new Queue();
            Queue s4 = new Queue();
            Stack s1 = new Stack();
            Stack s2 = new Stack();
            int n = array.Length;//bien n = so phan tu cua mang a               
            int[] evenArray = new int[n];
            int[] oddArray = new int[n];
            int i, j = 0, k = 0;
            for (i = 0; i < n; i++)
            {
                //Nếu chia hết cho 2 gán cho mảng even và tăng j thêm 1
                if (array[i] % 2 == 0)
                {
                    evenArray[j] = array[i];
                    j++;
                }
                else//ngược lại không chia hết cho 2 thì gán cho mảng odd và tăng k
                {
                    oddArray[k] = array[i];
                    k++;
                }
            }
            Console.WriteLine("\nCác số chẵn: ");
            for (i = 0; i < j; i++)
            {

                Console.WriteLine(evenArray[i]);
                //Su dung Push de dua vao hang doi
                s1.Push(evenArray[i]);
                s3.Enqueue(evenArray[i]);

            }
            Console.WriteLine("\nCác số lẻ: ");
            for (i = 0; i < k; i++)
            {
                Console.WriteLine(oddArray[i]);
                //Su dung Push de dua vao hang doi
                s2.Push(oddArray[i]);
                s4.Enqueue(oddArray[i]);

            }

            Console.WriteLine("\nDanh sách số chẵn ở hàng đợi: ");
            foreach (var item in s1)
            {
                Console.Write(" " + item);
                //Tạo đường dẫn để lưu file writer
                StreamWriter sw = new StreamWriter("C:\\Users\\Linewbie\\source\\repos\\Test_Queue_Doan\\even_queue.txt");
                foreach (var sw1 in s1)
                {
                    sw.WriteLine(sw1);

                }
                //đóng sw
                sw.Close();
            }
            Console.WriteLine("\nDanh sách số lẻ ở hàng đợi: ");
            foreach (var item in s2)
            {
                Console.Write(" " + item);
                StreamWriter sw = new StreamWriter("C:\\Users\\Linewbie\\source\\repos\\Test_Queue_Doan\\odd_queue.txt");
                foreach (var sw2 in s2)
                {
                    sw.WriteLine(sw2);
                }
                sw.Close();
            }


        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.OutputEncoding = Encoding.UTF8;
            var a = ReadArrayHex();
            PrintArray(a);
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Chọn một tùy chọn trong danh sách sau:");
            Console.WriteLine("\tss - Selection Sort");
            Console.WriteLine("\tbs - Binary Search");
            Console.WriteLine("\teo - Even and Odd");
            Console.WriteLine("\tex - Exit");

            Console.Write("Chọn lựa của bạn? ");

            switch (Console.ReadLine())
            {
                case "ss":
                    selectionSort(a);
                    PrintArray(a);
                    StreamWriter sw = new StreamWriter("C:\\Users\\Linewbie\\source\\repos\\Test_Queue_Doan\\sorted_numbers.txt");
                    foreach (var s in a)
                    {
                        sw.WriteLine(s);
                    }
                    sw.Close();
                    goto case "ex";

                case "bs":
                    Console.WriteLine("Mảng đã sắp xếp!!!");
                    selectionSort(a);
                    PrintArray(a);
                    Console.WriteLine("\nNhập giá trị x cần tìm: ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    var kq = binarySearch(a, x);
                    Console.WriteLine($"\nĐã tìm thấy x tại vị trí:{kq}");
                    goto case "ex";

                case "eo":
                    TachSoChanLe(a);
                    goto case "ex";

                case "ex":
                    Console.WriteLine("\nNhấn phím bất kỳ để thoát chương trình..");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
