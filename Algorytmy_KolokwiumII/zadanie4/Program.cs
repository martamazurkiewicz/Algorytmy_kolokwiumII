using System;
//Drzewo BST odczytano w porządku pre-order i otrzymano 6, 3, 1, 2, 4, 5, 7. 
//Czy możemy odtworzyć to drzewo? Napisz metodę odtwarzającą drzewo na podstawie odczytu pre-order, 
//jeżeli drzewa nie można odtworzyć (dane są sprzeczne np. 6, 3, 1, 2, 4, 7, 5) metoda ma zwracać drzewo puste.
namespace zadanie4
{
    class Node
    {
        public int value;
        public Node rightChild;
        public Node leftChild;
        public int Count()
        {
            if (rightChild != null && leftChild != null)
                return 2;
            if (rightChild != null || leftChild != null)
                return 1;
            else
                return 0;
        }
        public Node(int value)
        {
            this.value = value;
        }
    }
    class Tree
    {
        public Node root;

        public Tree(Node root)
        {
            this.root = root;
        }

        public Tree()
        {
        }

        //pre-order array 
        public static Tree CreateTree(Tree tree, int[] arr, int index, Node tmp)
        {
            if (arr.Length == 0)
            {
                return tree;
            }
            if (tree.root == null)
            {
                tree.root = new Node(arr[0]);
                return CreateTree(tree, arr, 1, tree.root);
            }
            if (index == arr.Length)
                return tree;
            if (tmp.value > arr[index])
            {
                //check if rightChilde exist => if so array is corrupted
                if (tmp.rightChild != null)
                {
                    tree.root = null;
                    return tree;
                }
                if (tmp.leftChild == null)
                { 
                    tmp.leftChild = new Node(arr[index]);
                    index += 1;
                    return CreateTree(tree, arr, index, tree.root);
                }
                //if (tmp.leftChild != null)
                return CreateTree(tree, arr, index, tmp.leftChild);
            }
            //if (tmp.value < arr[index])
            else
            {
                if (tmp.rightChild == null)
                {
                    tmp.rightChild = new Node(arr[index]);
                    index += 1;
                    return CreateTree(tree, arr, index, tree.root);
                }
                //if (tmp.rightChild != null)
                return CreateTree(tree,arr, index, tmp.rightChild);
            }
        }
        public void DisplayPostOrder(Node node)
        {
            if (node == null)
                return;
            DisplayPostOrder(node.leftChild);
            DisplayPostOrder(node.rightChild);
            Console.Write(node.value + " ");
        }
        public void DisplayPreOrder(Node node)
        {
            //displays tree pre-order
            if (node == null)
                return;
            Console.Write(node.value + " ");
            DisplayPreOrder(node.leftChild);
            DisplayPreOrder(node.rightChild);
        }
        public void DisplayInOrder(Node node)
        {
            if (node == null)
                return;
            DisplayInOrder(node.leftChild);
            Console.Write(node.value + " ");
            DisplayInOrder(node.rightChild);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] goodArr = { 6, 3, 1, 2, 4, 5, 7 };
            int[] badArr = { 6, 3, 1, 2, 4, 7, 5 };
            Tree good = new Tree();
            Tree bad = new Tree();
            Tree.CreateTree(good, goodArr, 0, good.root);
            Tree.CreateTree(bad, badArr, 0, bad.root);

            good.DisplayPostOrder(good.root);
            bad.DisplayPreOrder(bad.root);
            Console.ReadKey();
        }
    }
}
