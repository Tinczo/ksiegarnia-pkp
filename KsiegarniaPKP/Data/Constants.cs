using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace KsiegarniaPKP.Data
{
    public class Constants

    {
        public List<string> emaile = new List<string> { "uzytkownik@gmail.com", "kurier@gmail.com", "pracownik@gmail.com", "admin@gmail.com" };
        public List<string> hasla = new List<string> { "nUpass1!", "kUpass1!", "pUpass1!", "aUpass1!" };
        public List<string> imiona = new List<string> { "Szymon", "Karol", "Dawid", "Urszula" };
        public List<string> nazwiska = new List<string> { "Wieczorek", "Pilat", "Spalek", "Staszak" };
        public List<string> role = new List<string> { "Uzytkownik", "Kurier", "Pracownik", "Admin" };

        public string createId(int position)
        {
            string id = imiona[position] + nazwiska[position] + "_" + emaile[position];
            return id;
        }
    }
}
