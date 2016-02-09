using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace EduticXamarin.Pages
{
    public class MasterDetail : MasterDetailPage
    {
        public MasterDetail(String username)
        {
            Master = new Menu(username);
            Detail = new Contenido();
        }
    }
}
