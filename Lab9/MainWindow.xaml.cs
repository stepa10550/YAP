using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab9;

namespace Lab9
{
    public partial class MainWindow : Window
    {
        private Money money;
         
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateMoney_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                money = new Money(CheckEnteryData.CheckEnteryUint(RublesInput.Text), 
                    CheckEnteryData.CheckEnteryByte(KopeksInput.Text));
                OutputText.Text = $"Создана куча: {money}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Increment_Click(object sender, RoutedEventArgs e)
        {
            if (money == null)
            {
                MessageBox.Show($"Ошибка: куча не создана, чтобы с ней работать",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            money++;
            OutputText.Text = $"С ещё одной копейкой: {money}";
        }

        private void Decrement_Click(object sender, RoutedEventArgs e)
        {
            if (money == null)
            {
                MessageBox.Show($"Ошибка: куча не создана, чтобы с ней работать",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            money--;
            OutputText.Text = $"Без одной копейки: {money}";
        }

        private void AddKopeks_Click(object sender, RoutedEventArgs e)
        {
            if (money == null)
            {
                MessageBox.Show($"Ошибка: куча не создана, чтобы с ней работать",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            money = money.AddKopeks(CheckEnteryData.CheckEnteryUint(AddKopeksInput.Text));
            OutputText.Text = $"После добавки копеек: {money}";
        }

        private void AddItself_Click(object sender, RoutedEventArgs e)
        {
            if (money == null)
            {
                MessageBox.Show($"Ошибка: куча не создана, чтобы с ней работать",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var tempMoney = new Money(CheckEnteryData.CheckEnteryUint(RublesInput2.Text),
                        CheckEnteryData.CheckEnteryByte(KopeksInput2.Text));
                money = money + tempMoney;
                OutputText.Text = $"Сложение куч: {money}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SubtractSelf_Click(object sender, RoutedEventArgs e)
        {
            if (money == null)
            {
                MessageBox.Show($"Ошибка: куча не создана, чтобы с ней работать",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var tempMoney = new Money(CheckEnteryData.CheckEnteryUint(RublesInput2.Text),
                        CheckEnteryData.CheckEnteryByte(KopeksInput2.Text));
                money = money - tempMoney;
                OutputText.Text = $"Вычитание куч: {money}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
