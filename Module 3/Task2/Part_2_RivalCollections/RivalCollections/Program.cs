using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RivalCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //!!Comment and uncomment necessary methods. Find and Remove methods for every collection type necessary use together with Add methods.

            ArrListAdd();
            //LinkedListAdd();
            //StackAdd();
            //QueueAdd();
            //HashtabAdd();
            //DictionaryAdd();
            //ArrListFind();
            //LinkedListFind();
            //StackFind();
            //QueueFind();
            //HashtabFind();
            //DictionaryFind();
            ArrListRemove();
            //LinkedListRemove();
            //StackRemove();
            //QueueRemove();
            //HashtabRemove();
            //DictionaryRemove();

            Console.ReadLine();

        }


        static ArrayList AL = new ArrayList();
        static LinkedList<int> LL = new LinkedList<int>();
        static Stack StackList = new Stack();
        static Queue QueueList = new Queue();
        static Hashtable hashtable = new Hashtable();
        static Dictionary<string, int> Dict = new Dictionary<string, int>();


       //Add 100 values in collection and measure time. For 6 collection types.
        public static void ArrListAdd()
        {
            var Starttime1 = DateTime.Now.TimeOfDay; 
            var rnd1 = new Random();
            for (int i = 0; i < 100; i++)
            {
                int number = rnd1.Next(0, 1000);
                AL.Add(number);
            }
            var Endtime1 = DateTime.Now.TimeOfDay;
            string Outputvar1="";
            foreach (var item1 in AL)
            {
                string value1 = (string)item1.ToString();
                Outputvar1 = Outputvar1 + value1+" ";
               
            }

            Console.WriteLine("Array List" + "\n\n" + Outputvar1 + "\n\n" + "Time  to add= " + (Endtime1 - Starttime1) + "\n\n");
            
        }

        public static void LinkedListAdd()
        {
            var Starttime2 = DateTime.Now.TimeOfDay;  
            var rnd2 = new Random();
            for (int i = 0; i < 100; i++)
            {
                int number = rnd2.Next(0, 1000);
                LL.AddLast(number);
            }
            var Endtime2 = DateTime.Now.TimeOfDay;
            string Outputvar2 = "";

            foreach (var item2 in LL)
            {
                string value2 = (string)item2.ToString();
                Outputvar2 = Outputvar2 + value2 + " ";
            }

            Console.WriteLine("Linked List" + "\n\n" + Outputvar2 + "\n\n" + "Time to add = " + (Endtime2 - Starttime2) + "\n\n");
            
        }

        public static void StackAdd()
        {
            var Starttime3 = DateTime.Now.TimeOfDay;
            var rnd3 = new Random();
            for (int i = 0; i < 100; i++)
            {
                int number3 = rnd3.Next(0, 1000);
                StackList.Push(number3);
            }
            var Endtime3 = DateTime.Now.TimeOfDay;
            string Outputvar3 = "";
            foreach (var item3 in StackList)
            {
                string value3 = (string)item3.ToString();
                Outputvar3 = Outputvar3 + value3 + " ";
            }

            Console.WriteLine("Stack List" + "\n\n" + Outputvar3 + "\n\n" + "Time to add = " + (Endtime3 - Starttime3) + "\n\n");
        }

        public static void QueueAdd()
        {
            var Starttime4 = DateTime.Now.TimeOfDay;
            var rnd4 = new Random();
            for (int i = 0; i < 100; i++)
            {
                int number = rnd4.Next(0, 1000);
                QueueList.Enqueue(number);
            }
            var Endtime4 = DateTime.Now.TimeOfDay;
            string Outputvar4 = "";
            foreach (var item4 in QueueList)
            {
                string value4 = (string)item4.ToString();
                Outputvar4 = Outputvar4 + value4 + " ";
            }
            Console.WriteLine("Queue List" + "\n\n" + Outputvar4 + "\n\n" + "Time to add = " + (Endtime4 - Starttime4) + "\n\n");
        }
        public static void HashtabAdd()
        {
            var Starttime5 = DateTime.Now.TimeOfDay;
            
            var rnd5 = new Random();
            
            for (int i = 1; i < 101; i++)
            {
                int number = rnd5.Next(0, 1000);
                hashtable.Add("Key " + i, number);
            }
            var Endtime5 = DateTime.Now.TimeOfDay;
            string Outputvar5 = "";
            foreach (DictionaryEntry item5 in hashtable)
            {
                string value5 = (string)item5.Key.ToString() + " - " + (string)item5.Value.ToString()+" ";
                Outputvar5 = Outputvar5 + value5 + " ";
            }
            Console.WriteLine("Hashtable List" + "\n\n" + Outputvar5 + "\n\n" + "Time  to add = " + (Endtime5 - Starttime5) + "\n\n");
        }
            
            public static void DictionaryAdd()
        {
            var Starttime6 = DateTime.Now.TimeOfDay;
            var rnd = new Random();
            for (int i = 1; i < 101; i++)
            {
                int number = rnd.Next(0, 1000);
                Dict.Add("Key " + i, number);
            }
                var Endtime6 = DateTime.Now.TimeOfDay;
                string Outputvar6 = "";                      
                foreach (KeyValuePair<string, int> item6 in Dict)
            {
                string value6 = (string)item6.Key.ToString() + " - " + (string)item6.Value.ToString()+" ";
                Outputvar6 = Outputvar6 + value6 + " ";
            }
            Console.WriteLine("Dictionary" + "\n\n" + Outputvar6 + "\n\n" + "Time to add = " + (Endtime6 - Starttime6) + "\n\n");          
        }

            //Find the 50th element from collections. For 6 collection types. Run together with adding methods.

            public static void ArrListFind()
            {
                var Starttime7 = DateTime.Now.TimeOfDay;
                var item1 = AL[50]; 
                var Endtime7 = DateTime.Now.TimeOfDay;
                Console.WriteLine("Value {0}=", item1 + " Time to find=" + (Endtime7 - Starttime7));             
            }

            public static void LinkedListFind()
            {
                var Starttime8 = DateTime.Now.TimeOfDay;
                var item2 = LL.ElementAt(50);
                var Endtime8 = DateTime.Now.TimeOfDay;
                Console.WriteLine("Value = {0}", item2 + "   Time to find = " + (Endtime8 - Starttime8));
            }

            public static void StackFind()
            {
                var Starttime9 = DateTime.Now.TimeOfDay;
                var item3 = StackList.Peek();
                var Endtime9 = DateTime.Now.TimeOfDay;
                Console.WriteLine( "Value = {0}", item3 + "   Time to find = " + (Endtime9 - Starttime9));
            }

            public static void QueueFind()
            {
                var Starttime10 = DateTime.Now.TimeOfDay;
                var item4 = QueueList.Peek();
                var Endtime10 = DateTime.Now.TimeOfDay;
                Console.WriteLine("Value = {0}", item4 + "   Time to find = " + (Endtime10 - Starttime10));
            }

            public static void HashtabFind()
            {
                var Starttime11 = DateTime.Now.TimeOfDay;
                int item5 = (int) hashtable["Key 50"];
                var Endtime11 = DateTime.Now.TimeOfDay;
                Console.WriteLine("Value = {0}", item5 + "   Time to find = " + (Endtime11 - Starttime11));
            }

            public static void DictionaryFind()
            {
                var Starttime12 = DateTime.Now.TimeOfDay;
                int item6 = (int)Dict["Key 50"];
                var Endtime12 = DateTime.Now.TimeOfDay;
                Console.WriteLine("Value = {0}", item6 + "   Time to find = " + (Endtime12 - Starttime12));
            }

            //Remove all elements from collections. Run together with adding methods.

            public static void ArrListRemove()
            {
                var Starttime13 = DateTime.Now.TimeOfDay;                            
                    AL.Clear();
                var Endtime13 = DateTime.Now.TimeOfDay;
                Console.WriteLine("Time to remove ArrayList = " + (Endtime13 - Starttime13));
            }

            public static void LinkedListRemove()
            {
                var Starttime14 = DateTime.Now.TimeOfDay;
                LL.Clear();
                var Endtime14 = DateTime.Now.TimeOfDay;
                Console.WriteLine("Time to remove LinkedList = " + (Endtime14 - Starttime14));
            }

            public static void StackRemove()
            {
                var Starttime15 = DateTime.Now.TimeOfDay;
                StackList.Clear();
                var Endtime15 = DateTime.Now.TimeOfDay;
                Console.WriteLine("Time to remove stack = " + (Endtime15 - Starttime15));
            }

            public static void QueueRemove()
            {
                var Starttime16 = DateTime.Now.TimeOfDay;
                QueueList.Clear();
                var Endtime16 = DateTime.Now.TimeOfDay;
                Console.WriteLine("Time to remove QueueList = " + (Endtime16 - Starttime16));
            }

            
            public static void HashtabRemove()
            {
                var Starttime17 = DateTime.Now.TimeOfDay;
                hashtable.Clear();
                var Endtime17 = DateTime.Now.TimeOfDay;
                Console.WriteLine("Time to remove hashtable = " + (Endtime17 - Starttime17));
            }

            public static void DictionaryRemove()
            {
                var Starttime18 = DateTime.Now.TimeOfDay;
                Dict.Clear();
                var Endtime18 = DateTime.Now.TimeOfDay;
                Console.WriteLine("Time to remove dictionary = " + (Endtime18 - Starttime18));
            }


    }
}
             
        
       
