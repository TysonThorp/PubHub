using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;
namespace Capstone.DAO
{
    public class BeerSqlDao : IBeerDao
    {
        private readonly string connectionString;

        public BeerSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Beer AddBeer(Beer beer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Beer (beer_name, description, image, abv, beer_type) " +
                        "OUTPUT INSERTED.beer_id VALUES (@beer_id, @beer_name, @description, @image, @abv, @beer_type)", conn);
                    cmd.Parameters.AddWithValue("@beer_name", beer.Name);
                    cmd.Parameters.AddWithValue("@description", beer.Description);
                    cmd.Parameters.AddWithValue("@image", beer.Image);
                    cmd.Parameters.AddWithValue("@abv", beer.ABV);
                    cmd.Parameters.AddWithValue("@beer_type", beer.BeerType);

                    beer.BeerID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return beer;
        }

        public void DeleteBeer(int beerId)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Beer WHERE beer_id = @beer_id", conn);
                cmd.Parameters.AddWithValue("@beer_id", beerId);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Beer> GetAllBeers()
        {
            List<Beer> beerList = new List<Beer>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT beer_id, beer_name, description, image, abv, beer_type FROM Beer", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Beer beer = new Beer();
                        beer = GetBeerFromReader(reader);
                        beerList.Add(beer);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }


            return beerList;
        }

        private Beer GetBeerFromReader(SqlDataReader reader)
        {
            Beer beer = new Beer()
            {
                BeerID = Convert.ToInt32(reader["beer_id"]),
                Name = Convert.ToString(reader["beer_name"]),
                Description = Convert.ToString(reader["description"]),
                Image = Convert.ToString(reader["image"]),
                ABV = Convert.ToDecimal(reader["abv"]),
                BeerType = Convert.ToString(reader["beer_type"]),

            };

            return beer;
        }
    }
}
