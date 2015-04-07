using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RivalCollections
{
    public class Adding
    {
   



        public void ArrListMet()
        {
            var Starttime = DateTime.Now.TimeOfDay;
            ArrayList AL = new ArrayList();
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int number = rnd.Next(0, 1000);
                AL.Add(number);
            }

            foreach (var item in AL)
            {
                string value = (string)item.ToString();

                Console.WriteLine(value);
            }
            var Endtime = DateTime.Now.TimeOfDay;
            Console.WriteLine("Array List" + "\n" + (Endtime - Starttime) + "\n");
            Console.ReadLine();
        }


        //public void LinkedListMet()
        //{
        //    var Starttime = DateTime.Now.TimeOfDay;
        //    LinkedList<int> LL = new LinkedList<int>();
        //    var rnd = new Random();
        //    for (int i = 0; i < 100; i++)
        //    {
        //        int number = rnd.Next(0, 1000);
        //        LL.AddLast(number);
        //    }


        //    foreach (var item in LL)
        //    {
        //        string value = (string)item.ToString();
        //        Console.WriteLine(value);
        //    }
        //    var Endtime = DateTime.Now.TimeOfDay;
        //    Console.WriteLine("Linked List" + "\n" + (Endtime - Starttime) + "\n");
        //}

        //public void StackMet()
        //{
        //    var Starttime = DateTime.Now.TimeOfDay;
        //    Stack StackList = new Stack();

        //    var rnd = new Random();
        //    for (int i = 0; i < 100; i++)
        //    {
        //        int number = rnd.Next(0, 1000);
        //        StackList.Push(number);
        //    }

        //    foreach (var item in StackList)
        //    {
        //        string value = (string)item.ToString();
        //        Console.WriteLine(value);
        //    }
        //    var Endtime = DateTime.Now.TimeOfDay;
        //    Console.WriteLine("Stack List" + "\n" + (Endtime - Starttime) + "\n");
        //}

        //public void QueueMet()
        //{
        //    var Starttime = DateTime.Now.TimeOfDay;
        //    Queue QueueList = new Queue();

        //    var rnd = new Random();
        //    for (int i = 0; i < 100; i++)
        //    {
        //        int number = rnd.Next(0, 1000);
        //        QueueList.Enqueue(number);
        //    }
        //    foreach (var item in QueueList)
        //        Console.WriteLine(item);
        //    var Endtime = DateTime.Now.TimeOfDay;
        //    Console.WriteLine("Queue List" + "\n" + (Endtime - Starttime) + "\n");
        //}

        //public void HashtabMet()
        //{
        //    var Starttime = DateTime.Now.TimeOfDay;
        //    Hashtable hashtable = new Hashtable();
        //    var rnd = new Random();
        //    for (int i = 1; i < 101; i++)
        //    {
        //        int number = rnd.Next(0, 1000);
        //        hashtable.Add("Key " + i, number);
        //    }
        //    foreach (DictionaryEntry obj in hashtable)
        //        Console.WriteLine("{0} = {1}", obj.Key, obj.Value);
        //    var Endtime = DateTime.Now.TimeOfDay;
        //    Console.WriteLine("Hashtable" + "\n" + (Endtime - Starttime) + "\n");
        //}

        //public void DictionaryMet()
        //{
        //    var Starttime = DateTime.Now.TimeOfDay;
        //    Dictionary<string, int> Dict = new Dictionary<string, int>();
        //    var rnd = new Random();
        //    for (int i = 1; i < 101; i++)
        //    {
        //        int number = rnd.Next(0, 1000);
        //        Dict.Add("Key " + i, number);
        //    }
        //    foreach (KeyValuePair<string, int> obj in Dict)
        //        Console.WriteLine("{0} = {1}", obj.Key, obj.Value);
        //    var Endtime = DateTime.Now.TimeOfDay;
        //    Console.WriteLine("Dictionary" + "\n" + (Endtime - Starttime) + "\n");
        //    Console.ReadLine();
        //}
       
    }
}
