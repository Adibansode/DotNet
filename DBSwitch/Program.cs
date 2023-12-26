using MySql.Data.MySqlClient;
MySqlConnection conn = new MySqlConnection();
conn.ConnectionString = "server=192.168.10.150;port=3306;user=dac10;password=welcome;database=dac10";

string query = "select * from t1";
MySqlCommand command = new MySqlCommand(query, conn);







try
{
    conn.Open();
    int num;
    do
    {
        Console.WriteLine("Select choice:");
        Console.WriteLine("1.Display table \n 2.delete buy id \n3.Insert the data\n4.Exit");
        num = int.Parse(Console.ReadLine());
        switch (num)
        {
            case 1:
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["t1name"].ToString();
                    string job = reader["job"].ToString();
                    Console.WriteLine(id + " " + name + " " + job);
                }
                reader.Close();


                break;
            case 2:
                Console.WriteLine("enter id to delete");
                int did = int.Parse(Console.ReadLine());

                string dquery = "delete from t1 where id=" + did;
                Console.WriteLine(dquery);
                MySqlCommand command1 = new MySqlCommand(dquery, conn);

                command1.ExecuteNonQuery();
                break;
            case 3:
                Console.WriteLine("enter id to insert");
                Console.WriteLine("enter name to insert");
                Console.WriteLine("enter Job to insert");


                int iid = int.Parse(Console.ReadLine());
                String iname = Console.ReadLine();
                String ijob = Console.ReadLine();



                string iquery = "insert into t1 values(@id,@t1name,@job)";



                MySqlCommand command2 = new MySqlCommand(iquery, conn);
                command2.Parameters.AddWithValue("@id", iid);
                command2.Parameters.AddWithValue("@t1name", iname);
                command2.Parameters.AddWithValue("@job", ijob);
                 command2.ExecuteNonQuery();
                break;
            case 4:
                Console.WriteLine("Thank You");
                break;
        }


    } while (num != 4);

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    conn.Close();
}