using First_Site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;


namespace First_Site.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=Yazilim_Kitap;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("select Id,KitapAdi,Yazar from Yazilim_Kitaplari", conn);
            List<Kitaplar> Kitap = new List<Kitaplar>();

            conn.Open();

            SqlDataReader gg = cmd.ExecuteReader();
            while (gg.Read())
            {
                Kitap.Add(
                    new Kitaplar
                    {
                        Id = (int)gg["Id"],
                        KitapAdi = (string)gg["KitapAdi"],
                        Yazar = (string)gg["Yazar"],
                    });

            }
            conn.Close();
            return View(Kitap);

        }
    }

       

       
    }
