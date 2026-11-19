namespace WpfMVVM.Models
{
    /// <summary>
    /// Модель користувача для відображення в таблиці.
    /// Bogus заповнює властивості, тому сетери мають бути public.
    /// </summary>
    public class UserVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        // URL зображення. Перетворюється на ImageSource конвертером.
        public string Image { get; set; }
    }
}
