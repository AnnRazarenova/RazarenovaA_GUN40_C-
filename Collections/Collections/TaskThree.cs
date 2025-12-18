using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class TaskThree
    {
        public int size;
        public class Node 
        {
            public string value;
            
            public Node Next;

            public Node Prev;


        }

        public Node head;

        public Node tail;


        public void Push(string value)
        {
            Node newNode = new Node() { value = value };
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        public void WriteNext(Node head)
        {
            Node writeNextNode = head;

            while (writeNextNode != null)
            {
                Console.WriteLine(writeNextNode.value);
                writeNextNode = writeNextNode.Next;
            }
        }

        public void WritePrev(Node tail)
        {
            Node writePrevNode = tail;

            while (writePrevNode != null)
            {
                Console.WriteLine(writePrevNode.value);
                writePrevNode = writePrevNode.Prev;
            }
        }

        public void TaskLoop()
        {
            Console.WriteLine("Enter size of list(3-6)");

            size = int.Parse(Console.ReadLine());

            TaskThree list = new TaskThree();
            
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter node[" + (i+1) + "] value of list(3-6)");
                list.Push(Console.ReadLine());
            }

            Console.WriteLine("Forward:");
            WriteNext(list.head);

            Console.WriteLine();

            Console.WriteLine("Backward:");
            WritePrev(list.tail);

        }
    }
}
