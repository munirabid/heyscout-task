using Heyscot_DataAccess.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Heyscot_DataAccess
{
    public class MatchCustomerTalent
    {
        string connectionString = "";
        MySqlConnection conn;

        public MatchCustomerTalent(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public CustomerTalents GetCustomerTalents(string selectedType)
        {
            CustomerTalents customerTalents = new CustomerTalents();

            conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("GetData", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@selectedType", MySqlDbType.VarChar).Value = selectedType;

            conn.Open();

            try
            {
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                if(selectedType != "Talents")
                {
                    while (dr.Read())
                    {
                        Customer customer = new Customer
                        {
                            ID = dr.GetInt32("ID"),
                            Name = dr.GetString("Name"),
                            City = dr.GetString("City"),
                            RegistrationDate = dr.GetDateTime("RegistrationDate"),
                        };

                        customerTalents.Customers.Add(customer);
                    };
                }

                if (selectedType == "Talents")
                {
                    while (dr.Read())
                    {
                        Talent talent = new Talent
                        {
                            ID = dr.GetInt32("ID"),
                            Name = dr.GetString("Name"),
                            City = dr.GetString("City"),
                        };

                        customerTalents.Talents.Add(talent);
                    }
                }

                if (dr.NextResult())
                {
                    while (dr.Read())
                    {
                        Talent talent = new Talent
                        {
                            ID = dr.GetInt32("ID"),
                            Name = dr.GetString("Name"),
                            City = dr.GetString("City"),
                        };

                        customerTalents.Talents.Add(talent);
                    }
                }

                dr.Close();

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return customerTalents;
        }
    }
}
