using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Prog_poe_part2
{//start of namespace
    public class task_item
    {
        //start of properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class database_helper
    {
        private string connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=cybersecurty_bot;Trusted_Connection=True;";

        public database_helper()
        {
            initialize_database();
        }
        //end of constructor

        //start of method
        private void initialize_database()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection_string))
                {
                    conn.Open();

                    string create_table =
                        "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tasks' AND xtype='U') " +
                        "CREATE TABLE tasks (" +
                        "id INT IDENTITY(1,1) PRIMARY KEY," +
                        "title NVARCHAR(255) NOT NULL," +
                        "description NVARCHAR(MAX)," +
                        "is_completed BIT DEFAULT 0," +
                        "created_at DATETIME DEFAULT GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(create_table, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database setup error: " + ex.Message);
            }
        }
        //end of method


        //start of method
        public List<task_item> get_all_tasks()
        {
            List<task_item> tasks = new List<task_item>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connection_string))
                {
                    conn.Open();
                    string query = "SELECT id, title ,description, is_completed, created_at FROM tasks ORDER BY created_at_DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tasks.Add(new task_item
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                IsCompleted = reader.GetBoolean(3),
                                CreatedAt = reader.GetDateTime(4)

                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB error:" + ex.Message);
            }
            return tasks;
        }
        public bool add_task(string title, string description)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection_string))
                {
                    conn.Open();
                    string query = "INSERT INTO tasks (title,description) VALUES (@title,@desc)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue(@"desc", description);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB error:" + ex.Message);
                return false;
            }
        }

        public bool complete_task(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection_string))
                {
                    conn.Open();
                    string query = "UPDATE tasks SET is_completed = 1 WHERE id =@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB error:" + ex.Message);
                return false;
            }
        }//end of method
        public bool delete_task(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection_string))
                {
                    conn.Open();
                    string query = "DELETE FROM tasks WHERE id =@id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB error:" + ex.Message);
                return false;
            }
        }

    }
}//end of namespace
