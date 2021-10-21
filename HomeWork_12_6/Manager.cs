//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace HomeWork_12_6
//{
//    class Manager : Repository, IChanger
//    {
//        public override string ToString()
//        {
//            StringBuilder sb = new StringBuilder($"{"Фамилия",15} {"Имя",15} " +
//        $"{"Отчество",15} {"Телефон",15} {"Паспорт",15}");

//            foreach (Client client in clients)
//            {
//                sb.Append($"{client.LastName,15} {client.FirstName,15} " +
//                    $"{client.MiddleName,15} {client.TelephonNumber,15} {client.Pasport,15}");
//            }

//            return sb.ToString();
//        }


//        /// <summary>
//        /// Печать базы
//        /// </summary>
//        public override void PrintBD()
//        {
//            Console.WriteLine($"{"Фамилия",15} {"Имя",15} " +
//        $"{"Отчество",15} {"Телефон",15} {"Паспорт",15}");

//            foreach (Client client in clients)
//            {
//                Console.WriteLine($"{client.LastName,15} {client.FirstName,15} " +
//                    $"{client.MiddleName,15} {client.TelephonNumber,15} {client.Pasport,15}");
//            }

//        }

//        /// <summary>
//        /// создание записи для 
//        /// </summary>
//        /// <param name="firstName"></param>
//        /// <param name="lastName"></param>
//        /// <param name="middleName"></param>
//        /// <param name="telephonNumber"></param>
//        /// <param name="pasport"></param>
//        public override void Add(string firstName, string lastName, string middleName, decimal telephonNumber, string pasport)
//        {
//            Client client = new Client(firstName, lastName, middleName, telephonNumber, pasport);
//            client.SetChange("создан клиент", TypeOfChangesEnum.Create, typeof(Manager));

//            clients.Add(client);

//        }

//        /// <summary>
//        /// Сохраним базу в файл
//        /// </summary>
//        /// <param name="fileFullName"></param>
//        public override void SaveBD(string fileFullName)
//        {
//            string bd = JsonConvert.SerializeObject(clients);
//            File.WriteAllText(fileFullName, bd);
//        }

//        /// <summary>
//        /// Загрузка базы из файла
//        /// </summary>
//        /// <param name="fileFullName"></param>
//        public override void LoadBD(string fileFullName)
//        {
//            string json = File.ReadAllText(fileFullName);
//            clients = JsonConvert.DeserializeObject<List<Client>>(json);
//        }

//        /// <summary>
//        /// узнать паспорт
//        /// </summary>
//        /// <param name="index"></param>
//        /// <returns></returns>
//        public override string GetPasport(int index)
//        {
//            return clients[index].Pasport;
//        }

//        /// <summary>
//        /// сменить телефон
//        /// </summary>
//        /// <param name="newTelephon"></param>
//        /// <param name="index"></param>
//        public override void SetTelephon(decimal newTelephon, int index)
//        {
//            string textChange = $"изменился телефон был - {clients[index].TelephonNumber} стал - {newTelephon}";
//            clients[index].TelephonNumber = newTelephon;

//            ChangeClient(clients[index], textChange);
//        }

//        /// <summary>
//        /// сменить имя
//        /// </summary>
//        /// <param name="newFirstName"></param>
//        /// <param name="index"></param>
//        public void SetFirstName(string newFirstName, int index)
//        {
//            string textChange = $"изменилось имя было - {clients[index].FirstName} стало - {newFirstName}";
//            clients[index].FirstName = newFirstName;

//            ChangeClient(clients[index], textChange);

//        }

//        /// <summary>
//        /// Сменить фамилию
//        /// </summary>
//        /// <param name="newLastName"></param>
//        /// <param name="index"></param>
//        public void SetLastName(string newLastName, int index)
//        {
//            string textChange = $"изменилось фамилия была - {clients[index].LastName} стала - {newLastName}";
//            clients[index].LastName = newLastName;

//            ChangeClient(clients[index], textChange);
//        }

//        /// <summary>
//        /// Сменить отчество
//        /// </summary>
//        /// <param name="newLastName"></param>
//        /// <param name="index"></param>
//        public void SetMiddleName(string newMiddleName, int index)
//        {
//            string textChange = $"изменилось отчество было - {clients[index].MiddleName} стало - {newMiddleName}";
//            clients[index].MiddleName = newMiddleName;

//            ChangeClient(clients[index], textChange);
//        }

//        /// <summary>
//        /// заменить паспорт
//        /// </summary>
//        /// <param name="newLastName"></param>
//        /// <param name="index"></param>
//        public void SetPasport(string newPasport, int index)
//        {
//            string textChange = $"изменился паспорт был - {clients[index].Pasport} стал - {newPasport}";
//            clients[index].Pasport = newPasport;

//            ChangeClient(clients[index], textChange);
//        }

//        /// <summary>
//        /// сделать отметку об изменениях
//        /// </summary>
//        /// <param name="client"></param>
//        /// <param name="textChange"></param>
//        public void ChangeClient(Client client, string textChange)
//        {
//            client.SetChange(textChange, TypeOfChangesEnum.Changes, typeof(Manager));
//        }

//        /// <summary>
//        /// получить изменения
//        /// </summary>
//        /// <param name="client"></param>
//        /// <returns></returns>
//        public string GetChangeClinet(Client client)
//        {
//            return client.GetChange();
//        }
//    }
//}
