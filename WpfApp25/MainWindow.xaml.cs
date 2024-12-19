using System;
using System.Linq; // Подключите LINQ для использования методов расширений, таких как FirstOrDefault
using System.Windows;

namespace WpfApp25
{
    public partial class MainWindow : Window
    {
        private EquipmentRepairDBEntities _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new EquipmentRepairDBEntities();
        }



        private void AddRequestButton_Click(object sender, RoutedEventArgs e)
        {
            string equipmentName = EquipmentTextBox.Text;
            string faultTypeName = IssueTypeTextBox.Text;
            string problemDescription = DescriptionTextBox.Text;
            string clientName = ClientTextBox.Text;

            if (string.IsNullOrEmpty(equipmentName) || string.IsNullOrEmpty(faultTypeName) ||
                string.IsNullOrEmpty(problemDescription) || string.IsNullOrEmpty(clientName))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                MessageBox.Show($"Заявка успешно добавлена! Оборудование: {equipmentName}, Тип неисправности: {faultTypeName}");

                var equipment = _context.Equipment
                         .FirstOrDefault(eq => eq.EquipmentName.ToLower() == equipmentName.ToLower());

                var faultType = _context.FaultType
                                        .FirstOrDefault(ft => ft.FaultTypeName.ToLower() == faultTypeName.ToLower());



                if (equipment == null || faultType == null)
                {
                    MessageBox.Show("Некорректные данные для оборудования или типа неисправности.");
                    return;
                }

                // Получаем клиента из базы данных или создаем нового
                var client = _context.Client
                                     .FirstOrDefault(c => c.ClientName == clientName);

                if (client == null)
                {
                    // Если клиента нет в базе данных, создаем нового клиента
                    client = new Client
                    {
                        ClientName = clientName
                    };
                    _context.Client.Add(client);
                    _context.SaveChanges();  // Сохраняем клиента в базе данных
                }

                // Создание новой заявки
                Request newRequest = new Request
                {
                    EquipmentID = equipment.EquipmentID,
                    FaultTypeID = faultType.FaultTypeID,
                    ProblemDescription = problemDescription,
                    RequestDate = DateTime.Now,
                    StatusID = 1, // Default status
                    ClientID = client.ClientID  // Связь с клиентом
                };

                // Добавление новой заявки в контекст и сохранение изменений
                _context.Request.Add(newRequest);
                _context.SaveChanges();  // Сохраняем заявку в базе данных

                // Открываем окно подтверждения
                ConfirmationWindow confirmationWindow = new ConfirmationWindow("");
                confirmationWindow.ShowDialog();  // Показываем окно как диалог

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении заявки: {ex.Message}");
            }
        }


    }
}
