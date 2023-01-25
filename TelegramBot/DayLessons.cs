using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TelegramBot
{
    public class DayLessons
    {
        public string[] lessons = new string[5];
        public string[] teacher = new string[5];
        public string[] offise = new string[5];


        public int getCount()
        {
            return lessons.Length;
        }

        public void requestDB(string group/*, string even, string? weekday*/)
        {
            DB db = new DB();
            DataTable dTable = new DataTable();
            DateTime date = DateTime.Now;
            var dayofweek = date.DayOfWeek;
  
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM datalesson WHERE group1 = '{group}' AND UpDown = 'Четное' AND weekday = '{dayofweek.ToString()}'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(dTable);

            db.closeConnection();

            int count = dTable.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                var dtRow = dTable.Rows[i];
                lessons[i] = dtRow[2].ToString();
                teacher[i] = dtRow[5].ToString();
                offise[i] = dtRow[6].ToString();
            }
        }
    }
}
