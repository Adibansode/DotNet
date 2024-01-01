namespace BOL;

public class products
{
    public int pid { get; set; }
    public string pname { get; set; }

    public int pprice { get; set; }

    public int qty { get; set; }


public products(int pid,string pname){
        this.pid=pid;
        this.pname=pname;
   
    }
    public products(int pid,string pname,int pprice,int qty){
        this.pid=pid;
        this.pname=pname;
        this.pprice=pprice;
        this.qty=qty;
    }

}
