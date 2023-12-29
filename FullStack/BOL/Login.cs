namespace BOL;

public class Login
{
    public string username{get;set;}
        public string password{get;set;}
        public string email { get; set; }

        public Login(){

        }
          public Login(string email,string password){
            this.email=email;
            this.password=password;
        }
        public Login(string username,string email,string password){
            this.username=username;
            this.password=password;
            this.email = email;
        }


}
