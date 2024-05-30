using Microsoft.EntityFrameworkCore;
using ScaffoldTestConsoleApp.Models;

namespace ScaffoldTestConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        // Контекст БД позволяет с ней взаимодействовать
        // Лучше иметь не более одного экземпляра контекста на все приложение, воизбежание ошибок
        SaneyaskinContext db = new SaneyaskinContext();
        
        // Получение данных из таблиц
        // Т.к. между таблицами User и Role есть связь, их может быть много и с другими таблицами,
        // в свою очередь Include позволяет указать, какие связи стоит учитывать при отправке запроса 
        // если простыми словами, то он дает нам возможность подключить таблицу связанную таблицу,
        // чтобы получить данные и из нее тоже, в рамках одного запроса, своего рода аналог JOIN в SQL
        foreach (var user in db.Users.Include(r => r.IdRoleNavigation))
        {
            Console.WriteLine($"Login: {user.Login} - Password: {user.Password} - Phone: {user.PhoneNumber} - Role: {user.IdRoleNavigation.Name}");
        }
        Console.WriteLine("\n------------------------------------------------------------\n");
        
        foreach (var user in db.Users.Include(r => r.IdRoleNavigation)
                     .Where(r => r.IdRoleNavigation.Name == "Администратор"))
        {
            Console.WriteLine($"Login: {user.Login} - Password: {user.Password} - Phone: {user.PhoneNumber} - Role: {user.IdRoleNavigation.Name}");
            
        }

        // Добавление пользователя
        // Models.User newUser = new User()
        // {
        //     // Id нужно указывать, если у поля в таблице не стоит автоинкремента
        //     Id = 101,
        //     Login = "TEST USER",
        //     Password = "TEST",
        //     PhoneNumber = "00000000000",
        //     // IdRole это Id роли из таблицы Role
        //     IdRole = 1
        // };
        // // Добавляем нового пользователя, сохраняем изменения
        // db.Users.Add(newUser);
        // db.SaveChanges();

        // Находим и выводим информацию о добавленном пользователе
        // var testUser = db.Users.Include(r => r.IdRoleNavigation).FirstOrDefault(n => n.Login == "TEST USER");
        // Console.WriteLine($"Login: {testUser.Login} - Password: {testUser.Password} - Phone: {testUser.PhoneNumber} - Role: {testUser.IdRoleNavigation.Name}");

        // Находим и изменяем информацию у пользователя
        // var updateUser = db.Users.Include(r => r.IdRoleNavigation).FirstOrDefault(n => n.Login == "TEST USER");
        // updateUser.Login = "UPDATE";
        // db.SaveChanges();
        // Console.WriteLine($"Login: {updateUser.Login} - Password: {updateUser.Password} - Phone: {updateUser.PhoneNumber} - Role: {updateUser.IdRoleNavigation.Name}");
        
        // Удаляем созданного пользоватея
        // db.Users.Remove(testUser);
        // db.SaveChanges();
        
    }
}