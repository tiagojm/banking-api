using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Models
{
    public class BankingOperationsMongoSettings : IBankingOperationsMongoSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public bool UseSSL { get; set; }
    }

    public interface IBankingOperationsMongoSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        bool UseSSL { get; set; }
    }
}
