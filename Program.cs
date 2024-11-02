Console.WriteLine("Bienvenido a mi lista de Contactes");


//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            {
                Console.WriteLine("Digite el nombre de la persona");
                string name = Console.ReadLine();
                Console.WriteLine("Digite el apellido de la persona");
                string lastname = Console.ReadLine();
                Console.WriteLine("Digite la dirección");
                string address = Console.ReadLine();
                Console.WriteLine("Digite el telefono de la persona");
                string phone = Console.ReadLine();
                Console.WriteLine("Digite el email de la persona");
                string email = Console.ReadLine();
                Console.WriteLine("Digite la edad de la persona en números");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
                var temp = Convert.ToInt32(Console.ReadLine());
                bool isBestFriend;
                if (temp == 1)
                { isBestFriend = true; }
                else
                { isBestFriend = false; }
                //bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

                var id = ids.Count + 1;
                ids.Add(id);
                names.Add(id, name);
                lastnames.Add(id, lastname);
                addresses.Add(id, address);
                telephones.Add(id, phone);
                emails.Add(id, email);
                ages.Add(id, age);
                bestFriends.Add(id, isBestFriend);

                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2: //extract this to a method
            {
                Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                Console.WriteLine($"____________________________________________________________________________________________________________________________");
                foreach (var id in ids)
                {
                    var isBestFriend = bestFriends[id];

                    //string isBestFriendStr;

                    //if (isBestFriend == true)
                    //{
                    //    isBestFriendStr = "Si";
                    //}
                    //else {
                    //    isBestFriendStr = "No";
                    //}

                    string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
                    Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                }

            }
            break;
        case 3: //search
            {
                Console.WriteLine($"INGRESE EL NOMBRE DEL USUARIO");
                string userSearch = Console.ReadLine();

                Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                Console.WriteLine($"____________________________________________________________________________________________________________________________");
                foreach (var id in ids)
                {
                    
                    if (names[id] == userSearch)
                    {
                        string isBestFriendStr = bestFriends[id] ? "Si" : "No"; 
                        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                    }
                }





            }
            break;
        case 4: //modify
            {
                Console.WriteLine("Digite el teléfono del contacto que desea modificar:");
                string phoneToModify = Console.ReadLine();

                
                int idToModify = telephones.FirstOrDefault(x => x.Value == phoneToModify).Key;

                if (idToModify != 0) 
                {
                    Console.WriteLine("Digite el nuevo nombre de la persona (deje en blanco para no cambiar):");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName)) names[idToModify] = newName;

                    Console.WriteLine("Digite el nuevo apellido de la persona (deje en blanco para no cambiar):");
                    string newLastname = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newLastname)) lastnames[idToModify] = newLastname;

                    Console.WriteLine("Digite la nueva dirección (deje en blanco para no cambiar):");
                    string newAddress = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newAddress)) addresses[idToModify] = newAddress;

                    Console.WriteLine("Digite el nuevo email (deje en blanco para no cambiar):");
                    string newEmail = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newEmail)) emails[idToModify] = newEmail;

                    Console.WriteLine("Digite la nueva edad (deje en blanco para no cambiar):");
                    string ageInput = Console.ReadLine();
                    if (int.TryParse(ageInput, out int newAge)) ages[idToModify] = newAge;

                    Console.WriteLine("Especifique si es mejor amigo (1. Si, 2. No, deje en blanco para no cambiar):");
                    string bestFriendInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(bestFriendInput))
                    {
                        bool isBestFriend = bestFriendInput == "1";
                        bestFriends[idToModify] = isBestFriend;
                    }

                    Console.WriteLine("Contacto modificado con éxito.");
                }
                else
                {
                    Console.WriteLine("No se encontró un contacto con ese teléfono.");
                }
            
            }
            break;
        case 5: //delete
            {
                Console.WriteLine("Digite el teléfono del contacto que desea eliminar:");
                string phoneToDelete = Console.ReadLine();

                
                int idToDelete = telephones.FirstOrDefault(x => x.Value == phoneToDelete).Key;

                if (idToDelete != 0) 
                {
                    ids.Remove(idToDelete);
                    names.Remove(idToDelete);
                    lastnames.Remove(idToDelete);
                    addresses.Remove(idToDelete);
                    telephones.Remove(idToDelete);
                    emails.Remove(idToDelete);
                    ages.Remove(idToDelete);
                    bestFriends.Remove(idToDelete);

                    Console.WriteLine("Contacto eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("No se encontró un contacto con ese teléfono.");
                }
            
            }
            break;
        case 6:
            runing = false;
            break;
        default:
            Console.WriteLine("Tu eres o te haces el idiota?");
            break;
    }
}


static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el nombre de la persona");
    string name = Console.ReadLine();
    Console.WriteLine("Digite el apellido de la persona");
    string lastname = Console.ReadLine();
    Console.WriteLine("Digite la dirección");
    string address = Console.ReadLine();
    Console.WriteLine("Digite el telefono de la persona");
    string phone = Console.ReadLine();
    Console.WriteLine("Digite el email de la persona");
    string email = Console.ReadLine();
    Console.WriteLine("Digite la edad de la persona en números");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);
}