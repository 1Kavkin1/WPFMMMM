using System.Collections.ObjectModel;
using System.Windows;
using Bogus;
using WpfMVVM.Models;

namespace WpfMVVM
{
    /// <summary>
    /// Логіка головного вікна.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Колекція, до якої прив'язана таблиця.
        // ObservableCollection сповіщає DataGrid про зміни.
        private readonly ObservableCollection<UserVM> users = new();

        // Генератор випадкових даних Bogus.
        // "uk" - українська локаль.
        private readonly Faker<UserVM> _userFaker = new Faker<UserVM>("uk")
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber("+38(0##) ###-##-##"))
            .RuleFor(u => u.Image, f => $"https://i.pravatar.cc/1200?img={f.Random.Number(1, 70)}");

        public MainWindow()
        {
            InitializeComponent();

            dgvUsers.ItemsSource = users;

            // Одразу генеруємо 5 користувачів, щоб таблиця не була порожньою
            foreach (var user in _userFaker.Generate(5))
            {
                AddUser(user);
            }
        }

        /// <summary>
        /// Обробник кнопки "Додати": генерує одного випадкового користувача.
        /// </summary>
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            UserVM newUser = _userFaker.Generate();
            AddUser(newUser);
        }

        /// <summary>
        /// Призначає Id і додає користувача до колекції.
        /// </summary>
        private void AddUser(UserVM user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
        }
    }
}
