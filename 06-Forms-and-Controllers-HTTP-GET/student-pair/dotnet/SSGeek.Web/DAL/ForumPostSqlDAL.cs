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
            
                List<ForumPost> posts = new List<ForumPost>();

                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM forum_post ORDER BY post_date desc", conn);

                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var post = new ForumPost()
                            {
                                Username = Convert.ToString(reader["username"]),
                                Message = Convert.ToString(reader["message"]),
                                PostDate = Convert.ToDateTime(reader["post_date"]),
                                Subject = Convert.ToString(reader["subject"])
                            };

                            posts.Add(post);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw;
                }

                return posts;
            
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
