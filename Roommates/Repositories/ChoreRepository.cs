using Microsoft.Data.SqlClient;
using Roommates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//getAll getById insert

namespace Roommates.Repositories
{
    internal class ChoreRepository : BaseRepository
    {
        public ChoreRepository(string connectionString) : base(connectionString) { }

        public List<Chore> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select Id, Name from Chore";
                   
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Chore> chores = new List<Chore>();
                    while(reader.Read())
                    {
                        Chore chore = new Chore
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };
                        chores.Add(chore);
                    }

                    reader.Close();

                    return chores;
                }
            }
        }
    }
}
