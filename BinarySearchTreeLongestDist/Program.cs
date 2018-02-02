using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLongestDist
{
    class Program
    {
        static Node insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }
        static void Main(String[] args)
        {
            Node root = null;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                root = insert(root, data);
            }
            int height = getHeight(root);
            Console.WriteLine(height);

        }

        static int getHeight(Node root)
        {
            int len = 0;
            int rightlen = 0;
            int leftlen = 0;

        
            if (root.left == null && root.right == null)
            {
                return len;
            }
            len++;
            if (root.left!=null)
            {
                rightlen = len + getHeight(root.left);
            }
            if(root.right != null)
            {
                leftlen = len + getHeight(root.right);
            }
            len = leftlen > rightlen ? leftlen : rightlen;
            return len;
        }
    }

    internal class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }
}
