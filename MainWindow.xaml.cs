using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PozharovLab01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (birthdayPicker.SelectedDate == null)
            {
                MessageBox.Show("Обери дату!");
                return;
            }
            DateTime birthdate = (DateTime)birthdayPicker.SelectedDate;
            DateTime today = DateTime.Today;

            int age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age))
            {
                age--;
            }

            if (age < 0 || age > 135)
            {
                MessageBox.Show("Некоректна дата народження");
                return;
            }

            AgeTextBlock.Text = age.ToString();

            string[] westernSigns = {"Водолій", "Риби", "Овен", "Телець", "Близнюки", "Рак", "Лев", "Діва", "Терези", "Скорпіон", "Стрілець", "Козеріг" };
            int[] westernSignDates = {21, 20, 21, 21, 22, 22, 23, 22, 24, 24, 23, 23};
            int month = birthdate.Month;
            int day = birthdate.Day;
            int westernIndex = month - 1;
            if (day < westernSignDates[westernIndex])
            {
                westernIndex--;
                if (westernIndex < 0)
                {
                    westernIndex = 11;
                }
            }
            string westernSign = westernSigns[westernIndex];

            string[] chineseSigns = { "Щур", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза", "Мавпа", "Півень", "Собака", "Свиня" };
            int chineseYear = birthdate.Year;
            int chineseIndex = (chineseYear - 4) % 12;
            string chineseSign = chineseSigns[chineseIndex];

            WesternSignTextBlock.Text = westernSign;
            ChineseSignTextBlock.Text = chineseSign;

            if (birthdate.Month == today.Month && birthdate.Day == today.Day)
            {
                MessageBox.Show("З днем народження!");
            }
        }

    }
}
