namespace HashTableExample
{
    public class HashTable {
        //private string[] _table; // open addressing method
        LinkedList<string>[] _table; // chaining method
        private int _size;
        public HashTable(int size) {
            _size = size;
            //_table = new string[size]; // open addressing method
            _table = new LinkedList<string>[size]; // chaining method
        }

        private int GetHash(string name, bool quiet = false) {
            int ASCIIsum = 0;
            if (!quiet) Console.Write($"Calculating hash for '{name}': "); 

            foreach (char letter in name) {
                int ASCIIcode = (int)letter;
                ASCIIsum += ASCIIcode;
                if (!quiet) Console.Write($"'{letter}'({ASCIIcode}) + ");
            }

            if (!quiet) Console.WriteLine($"\nASCIIsum = {ASCIIsum}");

            int index = ASCIIsum % _size;

            return index;
        }

        public void Insert(string name) {
            Console.WriteLine($"Inserting '{name}' into the hash table.");

            int index = GetHash(name);

            // open addressing method with linear probing
            //int originalIndex = index;
            //while (_table[index] != null) { 
            //    Console.WriteLine($"Collision detected at index {index} for '{name}'. Probing to next index.");

            //    index = (index + 1) % _size; 

            //    if (index == originalIndex) {
            //        Console.WriteLine("Hash table is full. Cannot insert new name.");
            //        return;
            //    }
            //}
            //_table[index] = name;
            //Console.WriteLine($"'{name}' inserted at index {index}.");
            //

            // Chaining method
            if (_table[index] == null) {
                _table[index] = new LinkedList<string>();
                Console.WriteLine($"Index {index} is empty. Creating new chain");
            } else {
                Console.WriteLine($"Collision detected at index {index} for '{name}'. Adding to the existing chain.");
            }
            _table[index].AddLast(name);
            Console.WriteLine($"'{name}' added to chain at index {index}.");
            //
        }

        public string Search(string name) {
            Console.WriteLine($"Searching for '{name}' in the hash table.");

            int index = GetHash(name, true);

            // open addressing method
            //int originalIndex = index;
            //while (_table[index] != null) {

            //    if (_table[index] == name) {
            //        return _table[index];
            //    }

            //    index = (index + 1) % _size;
            //    if (index == originalIndex) {
            //        break; 
            //    }
            //}
            //

            // Chaining method
            if (_table[index] == null) {
                return null;
            }

            Console.WriteLine($"Looking inside chain at index {index}");

            foreach (string employee in _table[index]) {
                Console.WriteLine($"Checking '{employee}'.");
                if (employee == name) {
                    Console.Write($" '{employee}' was Found");
                    return employee;
                }
            }

            Console.WriteLine($" '{name}' was Not Found in the chain at index {index}.");
            //


            return null;
        }

        public void PrintTable() {
            Console.WriteLine("Hash Table Contents:");
            // open addressing method
            //for (int i = 0; i < _size; i++) {
            //    string value = _table[i] == null ? "[Empty]" : $"{_table[i]}";
            //    Console.WriteLine($"Index {i}: {value}");
            //}
            //

            // Chaining method
            for (int i = 0; i < _size; i++) {
                if (_table[i] == null) {
                    Console.WriteLine($"Index {i}: [Empty]");
                } else {
                    Console.Write($"Index {i}: ");
                    foreach (string name in _table[i]) {
                        Console.Write($"{name} -> ");
                    }
                    Console.WriteLine("null");
                }
            }
            //
            Console.WriteLine("---");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            HashTable hashTable = new HashTable(10);
            
            while (true)
            {
                Console.WriteLine("Choose an option:\n1. Insert Name\n2. Search Name\n3. Print Table\n4. Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter name to insert: ");
                        string nameToInsert = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nameToInsert)) hashTable.Insert(nameToInsert);
                        break;
                    case "2":
                        Console.Write("Enter name to search: ");
                        string nameToSearch = Console.ReadLine();
                        string result = hashTable.Search(nameToSearch);
                        if (result != null)
                        {
                            Console.WriteLine($"'{nameToSearch}' was found in the hash table.");
                        }
                        else
                        {
                            Console.WriteLine($"'{nameToSearch}' was not found in the hash table.");
                        }
                        break;
                    case "3":
                        hashTable.PrintTable();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
