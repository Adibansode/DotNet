namespace DAL;
using BOL;
using System.Net.Security;
using MySql.Data.MySqlClient;

public class DBManager
{
    public static Login validate(string username, string password){
       MySqlConnection conn = new MySqlConnection();
       conn.ConnectionString="server=192.168.10.150;port=3306;user=dac10;password=welcome;database=dac10";
        //    conn.ConnectionString="server=localhost;user=root;password=Aditya@8249;database=dotnet";

       string query="select * from login where username=@username and password=@password";
       MySqlCommand command =new MySqlCommand(query,conn);
       conn.Open();
        command.Parameters.AddWithValue("@username",username);
        command.Parameters.AddWithValue("@password",password);


        MySqlDataReader reader = command.ExecuteReader();
        // if(reader==null){
        //     return false;
        //     conn.Close();
        // }
        Login e=null;
        bool flag = false;
        while(reader.Read()){
            e = new Login(reader["username"].ToString(),reader["email"].ToString(),reader["password"].ToString());
            flag = true;
        }
        if(flag){
            conn.Close();
            return e;
        }
        conn.Close();
        return e;

                conn.Close();

    
    }



      public static void InsertData(string username, string password, string email)
    {
         MySqlConnection conn = new MySqlConnection();
    conn.ConnectionString="server=192.168.10.150;port=3306;user=dac10;password=welcome;database=dac10";
            //    conn.ConnectionString="server=localhost;user=root;password=Aditya@8249;database=dotnet";

    string query = "insert into Login values(@username,@password,@email)";
    MySqlCommand command = new MySqlCommand(query, conn);

       
    conn.Open();
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", password);
        command.Parameters.AddWithValue("@email", email);
        command.ExecuteNonQuery();
        conn.Close();

    }



   



}
