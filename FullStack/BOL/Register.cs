namespace BOL;

public class Register
{
    public string email{get;set;}
        public string password{get;set;}

        public Register(){

        }
        public Register(string email,string password){
            this.email=email;
            this.password=password;
        }


}
