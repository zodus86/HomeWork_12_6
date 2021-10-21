using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWork_12_6
{
    public class Repository
    {

        public List<Client> clients = new List<Client>();

        /// <summary>
        /// Заполнения списка клиентов
        /// </summary>
        /// <param name="fileFullName"></param>
        public void InstallBase()
        {
            clients = new List<Client>();

            for (uint i = 1; i <= 5; i++)
            {
                clients.Add(new Client($"Имя_{i}", $"Фамилия_{i}", $"Отчество{i}", 88000000000 + i, "44 01 46600" + i));
            }
        }

        /// <summary>
        /// Печать базы
        /// </summary>
        public void PrintBD()
        {
            Console.WriteLine($"{"Фамилия",15} {"Имя",15} " +
        $"{"Отчество",15} {"Телефон",15} {"Паспорт",15}");

            foreach (Client client in clients)
            {
                Console.WriteLine($"{client.LastName,15} {client.FirstName,15} " +
                    $"{client.MiddleName,15} {client.TelephonNumber,15} {client.Pasport,15}");
            }

        }

        /// <summary>
        /// получить имя
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetFirstName(int index)
        {
            return clients[index].FirstName;
        }

        /// <summary>
        /// Получить фамилию
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetLasttName(int index)
        {
            return clients[index].LastName;
        }

        /// <summary>
        /// Получить Отчество
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetMiddleName(int index)
        {
            return clients[index].MiddleName;
        }

        /// <summary>
        /// Получить телефон
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public decimal GetTelephon(int index)
        {
            return clients[index].TelephonNumber;
        }

        /// <summary>
        /// Показать последние изменения
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetChange(int index)
        {
            return clients[index].GetChange();
        }


        /// <summary>
        /// создание записи для 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="middleName"></param>
        /// <param name="telephonNumber"></param>
        /// <param name="pasport"></param>
        public void Add(string firstName, string lastName, string middleName, decimal telephonNumber, string pasport)
        {
            Client client = new Client(firstName, lastName, middleName, telephonNumber, pasport);
            client.SetChange("создан клиент", TypeOfChangesEnum.Create, Users.Manager);

            clients.Add(client);

        }

        /// <summary>
        /// Сохраним базу в файл
        /// </summary>
        /// <param name="fileFullName"></param>
        public void SaveBD(string fileFullName)
        {
            string bd = JsonConvert.SerializeObject(clients);
            File.WriteAllText(fileFullName, bd);
        }

        /// <summary>
        /// Загрузка базы из файла
        /// </summary>
        /// <param name="fileFullName"></param>
        public void LoadBD(string fileFullName)
        {
            string json = File.ReadAllText(fileFullName);
            clients = JsonConvert.DeserializeObject<List<Client>>(json);
        }

        /// <summary>
        /// узнать паспорт
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetPasport(int index)
        {
            return clients[index].Pasport;
        }

        /// <summary>
        /// сменить телефон
        /// </summary>
        /// <param name="newTelephon"></param>
        /// <param name="index"></param>
        public void SetTelephon(decimal newTelephon, int index)
        {
            string textChange = $"изменился телефон был - {clients[index].TelephonNumber} стал - {newTelephon}";
            clients[index].TelephonNumber = newTelephon;

            ChangeClient(clients[index], textChange, Users.Manager);
        }

        /// <summary>
        /// сменить имя
        /// </summary>
        /// <param name="newFirstName"></param>
        /// <param name="index"></param>
        public void SetFirstName(string newFirstName, int index)
        {
            string textChange = $"изменилось имя было - {clients[index].FirstName} стало - {newFirstName}";
            clients[index].FirstName = newFirstName;

            ChangeClient(clients[index], textChange, Users.Manager);

        }

        /// <summary>
        /// Сменить фамилию
        /// </summary>
        /// <param name="newLastName"></param>
        /// <param name="index"></param>
        public void SetLastName(string newLastName, int index)
        {
            string textChange = $"изменилось фамилия была - {clients[index].LastName} стала - {newLastName}";
            clients[index].LastName = newLastName;

            ChangeClient(clients[index], textChange, Users.Manager);
        }

        /// <summary>
        /// Сменить отчество
        /// </summary>
        /// <param name="newLastName"></param>
        /// <param name="index"></param>
        public void SetMiddleName(string newMiddleName, int index)
        {
            string textChange = $"изменилось отчество было - {clients[index].MiddleName} стало - {newMiddleName}";
            clients[index].MiddleName = newMiddleName;

            ChangeClient(clients[index], textChange, Users.Manager);
        }

        /// <summary>
        /// заменить паспорт
        /// </summary>
        /// <param name="newLastName"></param>
        /// <param name="index"></param>
        public void SetPasport(string newPasport, int index)
        {
            string textChange = $"изменился паспорт был - {clients[index].Pasport} стал - {newPasport}";
            clients[index].Pasport = newPasport;

            ChangeClient(clients[index], textChange, Users.Manager);
        }

        /// <summary>
        /// сделать отметку об изменениях
        /// </summary>
        /// <param name="client"></param>
        /// <param name="textChange"></param>
        public void ChangeClient(Client client, string textChange, Users user)
        {
            client.SetChange(textChange, TypeOfChangesEnum.Changes, user);
        }

        /// <summary>
        /// получить изменения
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public string GetChangeClinet(Client client)
        {
            return client.GetChange();
        }
    }
}
