using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class User
{
    public string username;
    public string email;
    public string[] NBDexEntries;
    public string[] collectables;

    public User() { 
    }

    public User(string username, string email) {
        this.username = username;
        this.email = email;
    }
}
