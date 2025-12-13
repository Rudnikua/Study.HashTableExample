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

        public void Insert(string name) {
            Console.WriteLine($"Inserting '{name}' into the hash table.");

            int index = GetHash(name);
            int originalIndex = index;

            while (_table[index] != null) {
                Console.WriteLine($"Collision detected at index {index} for '{name}'. Probing to next index.");

                index = (index + 1) % _size;

                if (index == originalIndex) {
                    Console.WriteLine("Hash table is full. Cannot insert new name.");
                    return;
                }
            }

            _table[index] = name;
            Console.WriteLine($"'{name}' inserted at index {index}.");
        }

        public void PrintTable() {
            Console.WriteLine("Hash Table Contents:");
            for (int i = 0; i < _size; i++) {
                string value = _table[i] == "null" ? "[Empty]" : $"{_table[i]}";
                Console.WriteLine($"Index {i}: {value}");
            }
            Console.WriteLine("---");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            HashTable hashTable = new HashTable(10);
            
            hashTable.Insert("Sam");

            hashTable.Insert("Bob");

            hashTable.Insert("Charlie");

            hashTable.PrintTable();
        }
    }
}
