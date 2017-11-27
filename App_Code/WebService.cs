using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Сводное описание для WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Раскомментируйте следующую строку в случае использования сконструированных компонентов 
        //InitializeComponent(); 
    }

    static List<string> users = new List<string>();    // Список пользователей с их координатами.

    [WebMethod]
    public string[] getUsers()
    {
        return users.ToArray();                 // Вернуть полный список пользователей с их координатами.
    }

    [WebMethod]
    public void setUser(string usr, string lat, string lng)
    {

        int i = users.FindIndex(s => s == usr);     // Найти пользователя.
        if (i >= 0)                                 // Если пользователь найден, то
        {
            users[i + 1] = lat;                     // Обновить значение его широты
            users[i + 2] = lng;                     // и долготы в списке.
        }
        else                                        // Если пользователь не найден
        {
            users.Add(usr); users.Add(lat); users.Add(lng); // То добавить нового пользователя в конец.
        }
    }
}