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
using System.Windows.Shapes;

namespace CSB_Prog_WPF
{
    /// <summary>
    /// Логика взаимодействия для saleGoods.xaml
    /// </summary>
    public partial class saleGoods : Window
    {
        public int idUser;
        public saleGoods(int _idUser)
        {
            InitializeComponent();
            idUser = _idUser;
        }

        

    }
}
