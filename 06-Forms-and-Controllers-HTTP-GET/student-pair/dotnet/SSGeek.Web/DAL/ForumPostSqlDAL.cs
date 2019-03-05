using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SSGeek.Web.Models;

namespace SSGeek.Web.DAL
{
    public class ForumPostSqlDAL 
    {
        private string _connectionString;

        public ForumPostSqlDAL(string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<ForumPost> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public bool SaveNewPost(ForumPost post)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO forum_post VALUES (@Username, @Subject, @Message, CURRENT_TIMESTAMP);", conn);
                    cmd.Parameters.AddWithValue("@Username", post.Username);
                    cmd.Parameters.AddWithValue("@Subject", post.Subject);
                    cmd.Parameters.AddWithValue("@Message", post.Message);

                    cmd.ExecuteNonQuery();
                }

                result = true;
            }
            catch (SqlException ex)
            {
                throw;
            }

            return result;
        }
    }
}
