using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace Thiet_ke.Objects
{
    public interface IListUpdate<T>
    {
       void Nhap(string filePath, T doiTuong);
       void Sua(string filePath, T doiTuong);
       void Xoa(string filePath, string maDoiTuong);
       void TimKiem(ListView listView, string searchText);
    }
}
