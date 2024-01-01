namespace DAL;
using BOL;
using MySql.Data.MySqlClient;
public class DBManager
{

    public static List<products> GetAllProducts()
    {
        List<products> list= new List<products>();


        MySqlConnection conn = new MySqlConnection();
        // conn.ConnectionString = "server=192.168.10.150;port=3306;user=dac10;password=welcome;database=dac10";
        conn.ConnectionString = "server=localhost;user=root;password=Aditya@8249;database=dotnet";

        

        string query = "select * from product";
        MySqlCommand command = new MySqlCommand(query, conn);



        try
        {
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["pid"].ToString());
                string pname = reader["pname"].ToString();
                int pprice = int.Parse(reader["pprice"].ToString());
                int qty= int.Parse(reader["qty"].ToString());


                list.Add(new products(id,pname,pprice,qty));
            }
            reader.Close();
              }
            finally{
                conn.Close();
            }
            return list;
      

    }

    public static void updatebyid(int pid,string pname){
          MySqlConnection conn = new MySqlConnection();
        // conn.ConnectionString = "server=192.168.10.150;port=3306;user=dac10;password=welcome;database=dac10";
                conn.ConnectionString = "server=localhost;user=root;password=Aditya@8249;database=dotnet";

          conn.Open();

        string query = "update product set pname=@pname where pid=@id";
        MySqlCommand command = new MySqlCommand(query, conn);
        command.Parameters.AddWithValue("@id",pid);
        command.Parameters.AddWithValue("@pname",pname);
        command.ExecuteNonQuery();
    Console.WriteLine(query);
    conn.Close();
    }


     public static void insert(int pid,string pname,int pprice,int qty){
          MySqlConnection conn = new MySqlConnection();
        // conn.ConnectionString = "server=192.168.10.150;port=3306;user=dac10;password=welcome;database=dac10";
                conn.ConnectionString = "server=localhost;user=root;password=Aditya@8249;database=dotnet";

          conn.Open();

        string query = "insert into product values(@id,@pname,@price,@qty)";
        MySqlCommand command = new MySqlCommand(query, conn);
        command.Parameters.AddWithValue("@id",pid);
        command.Parameters.AddWithValue("@pname",pname);
        command.Parameters.AddWithValue("@price",pprice);
        command.Parameters.AddWithValue("@qty",qty);
        command.ExecuteNonQuery();
    Console.WriteLine(query);
    conn.Close();
    }


     public static void Deletebyid(int pid){
          MySqlConnection conn = new MySqlConnection();
        // conn.ConnectionString = "server=192.168.10.150;port=3306;user=dac10;password=welcome;database=dac10";
                conn.ConnectionString = "server=localhost;user=root;password=Aditya@8249;database=dotnet";

          conn.Open();

        string query = "delete from product where pid=@id";
        MySqlCommand command = new MySqlCommand(query, conn);
        command.Parameters.AddWithValue("@id",pid);
             command.ExecuteNonQuery();
    Console.WriteLine(query);
    conn.Close();
    }



}
