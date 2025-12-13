namespace HashTableExample
{
    public class HashTable {
        private string[] _table;
        private int _size;
        public HashTable(int size) {
            _size = size;
            _table = new string[size];
        }

        private int GetHash(string name) {
            int ASCIIsum = 0;
            Console.Write($"Calculating hash for '{name}': ");

            foreach (char letter in name) {
                int ASCIIcode = (int)letter;
                ASCIIsum += ASCIIcode;
                Console.Write($"'{letter}'({ASCIIcode}) + ");
            }

            int index = ASCIIsum % _size;

            Console.WriteLine($"'{name}' is stored at index: {index} ");

            return index;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
